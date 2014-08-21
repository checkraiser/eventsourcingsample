using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore
{
    public interface IEvent
    {
        Guid Id { get; }
    }
    [Serializable]
    public class Event : IEvent
    {
        public int Version;
        public Guid AggregateId { get; set; }
        public Guid Id { get; private set; }
    }
    public interface IHandle<TEvent> where TEvent : Event
    {
        void Handle(TEvent e);
    }
    public interface IEventHandler<TEvent> where TEvent : Event
    {
        void Handle(TEvent handle);
    }
}
