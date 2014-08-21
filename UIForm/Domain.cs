using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESCore;
namespace UIForm
{
    public class Item : AggregateRoot,
        IHandle<ItemCreatedEvent>,
        IHandle<ItemDescriptionChangedEvent>,
        IHandle<ItemCompletedChangedEvent>
    {
        public bool Completed { get; set; }
        public string Description { get; set; }

        public Item()
        {

        }

        public Item(Guid id, string description)
        {
            ApplyChange(new ItemCreatedEvent(id, description));
        }


        public void ChangeDescription(string description)
        {
            ApplyChange(new ItemDescriptionChangedEvent(Id, description));
        }

        public void ChangeCompleted(bool completed)
        {
            ApplyChange(new ItemCompletedChangedEvent(Id, completed));
        }

        public void Handle(ItemCreatedEvent e)
        {
            Id = e.AggregateId;
            Description = e.Description;
            Completed = false;
            Version = e.Version;
        }


        public void Handle(ItemDescriptionChangedEvent e)
        {
            Description = e.Description;
        }

        public void Handle(ItemCompletedChangedEvent e)
        {
            Completed = e.Completed;
        }
    }
}
