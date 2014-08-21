using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore
{
    public class EventBus : IEventBus
    {
        private IEventHandlerFactory _eventHandlerFactory;
        public EventBus(IEventHandlerFactory eventHandlerFactory)
        {
            _eventHandlerFactory = eventHandlerFactory;
        }

        public void Publish<T>(T @event) where T : Event
        {
            var handlers = _eventHandlerFactory.GetHandlers<T>();
            foreach (var eventHandler in handlers)
            {
                eventHandler.Handle(@event);
            }
        }
    }
    public interface ICommandBus
    {
        void Send<T>(T command) where T : Command;
    }
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : Event;
    }
    public class CommandBus : ICommandBus
    {
        private readonly ICommandHandlerFactory _commandHandlerFactory;

        public CommandBus(ICommandHandlerFactory commandHandlerFactory)
        {
            _commandHandlerFactory = commandHandlerFactory;
        }

        public void Send<T>(T command) where T : Command
        {
            var handler = _commandHandlerFactory.GetHandler<T>();
            if (handler != null)
            {
                handler.Execute(command);
            }
            else
            {
                throw new UnregisteredDomainCommandException("no handler registered");
            }
        }
    }
}
