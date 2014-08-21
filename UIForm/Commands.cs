using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESCore;
namespace UIForm
{
    public class CreateItemCommand : Command
    {        
        public string Description { get; internal set; }        
        public CreateItemCommand(Guid aggregateId,
            string description, int version)
            : base(aggregateId, version)
        {            
            Description = description;            
        }
    }

    public class ChangeItemDescriptionCommand : Command
    {
        public string Description { get; internal set; }
        public ChangeItemDescriptionCommand(Guid aggregateId,
            string description, int version)
            : base(aggregateId, version)
        {
            Description = description;
        }
    }

    public class ChangeItemCompletedCommand : Command
    {
        public bool Completed { get; internal set; }
        public ChangeItemCompletedCommand(Guid aggregateId,
            bool completed, int version)
            : base(aggregateId, version)
        {
            Completed = completed;
        }
    }
}
