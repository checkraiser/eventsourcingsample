using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore
{
    public interface IEventStorage
    {
        IEnumerable<Event> GetEvents(Guid aggregateId);
        void Save(AggregateRoot aggregate);
        IEnumerable<Event> Events();
    }
    public class InMemoryEventStorage : IEventStorage
    {
        private List<Event> _events;
        

        private readonly IEventBus _eventBus;

        public InMemoryEventStorage(IEventBus eventBus)
        {
            _events = new List<Event>();            
            _eventBus = eventBus;
        }
        public IEnumerable<Event> Events()
        {
            return _events;
        }
        public IEnumerable<Event> GetEvents(Guid aggregateId)
        {
            var events = _events.Where(p => p.AggregateId == aggregateId).Select(p => p);
            if (events.Count() == 0)
            {
                throw new AggregateNotFoundException(string.Format("Aggregate with Id: {0} was not found", aggregateId));
            }
            return events;
        }

        public void Save(AggregateRoot aggregate)
        {
            var uncommittedChanges = aggregate.GetUncommittedChanges();
            var version = aggregate.Version;

            foreach (var @event in uncommittedChanges)
            {
                version++;
                
                @event.Version = version;
                _events.Add(@event);
            }
            foreach (var @event in uncommittedChanges)
            {
                var desEvent = Converter.ChangeTo(@event, @event.GetType());
                _eventBus.Publish(desEvent);
            }
        }
    }
}
