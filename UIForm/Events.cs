using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESCore;
namespace UIForm
{
    public class ItemCreatedEvent : Event
    {        
        public string Description { get; internal set; }        
        public ItemCreatedEvent(Guid aggregateId, string description)
        {
            AggregateId = aggregateId;            
            Description = description;        
        }
        public override string ToString()
        {
            return this.GetType() + ", aggregateId: " + AggregateId + ", description: " + Description + ", version: " + Version;
        }
    }
    public class ItemDescriptionChangedEvent : Event
    {
        public string Description { get; internal set; }
        public ItemDescriptionChangedEvent(Guid aggregateId, string description)
        {
            AggregateId = aggregateId;
            Description = description;
        }
        public override string ToString()
        {
            return this.GetType() + ", aggregateId: " + AggregateId + ", description: " + Description + ", version: " + Version;
        }
    }
    public class ItemCompletedChangedEvent : Event
    {
        public bool Completed { get; internal set; }
        public ItemCompletedChangedEvent(Guid aggregateId, bool completed)
        {
            AggregateId = aggregateId;
            Completed = completed;
        }
        public override string ToString()
        {
            return this.GetType() + ", aggregateId: " + AggregateId + ", completed: " + Completed + ", version: " + Version;
        }
    }
    
}
