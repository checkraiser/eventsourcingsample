using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore
{
    public interface IRepository<T> where T : AggregateRoot, new()
    {
        void Save(AggregateRoot aggregate, int expectedVersion);
        T GetById(Guid id);
    }
    public class Repository<T> : IRepository<T> where T : AggregateRoot, new()
    {
        private readonly IEventStorage _storage;
        private static object _lockStorage = new object();

        public Repository(IEventStorage storage)
        {
            _storage = storage;
        }

        public void Save(AggregateRoot aggregate, int expectedVersion)
        {
            if (aggregate.GetUncommittedChanges().Any())
            {
                lock (_lockStorage)
                {
                    var item = new T();

                    if (expectedVersion != -1)
                    {
                        item = GetById(aggregate.Id);
                        if (item.Version != expectedVersion)
                        {
                            throw new ConcurrencyException(string.Format("Aggregate {0} has been previously modified",
                                                                         item.Id));
                        }
                    }

                    _storage.Save(aggregate);
                }
            }
        }

        public T GetById(Guid id)
        {
            IEnumerable<Event> events;
            events = _storage.GetEvents(id);            
            var obj = new T();            
            obj.LoadsFromHistory(events);
            return obj;
        }
    }
}
