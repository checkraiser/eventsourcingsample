using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESCore;
namespace UIForm
{
    public class CreateItemCommandHandler : ICommandHandler<CreateItemCommand>
    {
        private IRepository<Item> _repository;

        public CreateItemCommandHandler(IRepository<Item> repository)
        {
            _repository = repository;
        }

        public void Execute(CreateItemCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            if (_repository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }
            var aggregate = new Item(command.Id,command.Description);
            aggregate.Version = -1;
            _repository.Save(aggregate, aggregate.Version);
        }
    }

    public class ChangeItemCompletedCommandHandler : ICommandHandler<ChangeItemCompletedCommand>
    {
        private IRepository<Item> _repository;

        public ChangeItemCompletedCommandHandler(IRepository<Item> repository)
        {
            _repository = repository;
        }

        public void Execute(ChangeItemCompletedCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            if (_repository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }
            //var aggregate = new Item(command.Id, command.Description);
            var aggregate = _repository.GetById(command.Id);
            //aggregate.Completed = command.Completed;
            aggregate.ChangeCompleted(command.Completed);
            _repository.Save(aggregate, aggregate.Version);
        }
    }

    public class ChangeItemDescriptionCommandHandler : ICommandHandler<ChangeItemDescriptionCommand>
    {
        private IRepository<Item> _repository;

        public ChangeItemDescriptionCommandHandler(IRepository<Item> repository)
        {
            _repository = repository;
        }

        public void Execute(ChangeItemDescriptionCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            if (_repository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }
            //var aggregate = new Item(command.Id, command.Description);
            var aggregate = _repository.GetById(command.Id);
            //aggregate.Completed = command.Completed;
            aggregate.ChangeDescription(command.Description);
            _repository.Save(aggregate, aggregate.Version);
        }
    }
}
