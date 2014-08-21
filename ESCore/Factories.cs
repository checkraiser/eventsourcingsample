using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
namespace ESCore
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : Event;
    }
    public class StructureMapEventHandlerFactory: IEventHandlerFactory
    {
        private IContainer _container;
        public StructureMapEventHandlerFactory(IContainer container)
        {
            _container = container;
        }
        public IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : Event
        {
            var handlers = GetHandlerType<T>();

            var lstHandlers = handlers.Select(handler => (IEventHandler<T>)_container.GetInstance(handler)).ToList();
            return lstHandlers;
        }

        private static IEnumerable<Type> GetHandlerType<T>() where T : Event
        {
            IEnumerable<Type> types =
               from a in AppDomain.CurrentDomain.GetAssemblies()
               from t in a.GetTypes()
               select t;           
            var handlers = types
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IEventHandler<>))).Where(h => h.GetInterfaces().Any(ii => ii.GetGenericArguments().Any(aa => aa == typeof(T)))).ToList();


            return handlers;
        }
    }

    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandler<T>() where T : Command;
    }
    public class StructureMapCommandHandlerFactory : ICommandHandlerFactory
    {
        private IContainer _container;
        public StructureMapCommandHandlerFactory(IContainer container)
        {
            _container = container;
        }
        public ICommandHandler<T> GetHandler<T>() where T : Command
        {
            var handlers = GetHandlerTypes<T>().ToList();

            var cmdHandler = handlers.Select(handler =>
                (ICommandHandler<T>)_container.GetInstance(handler)).FirstOrDefault();

            return cmdHandler;
        }

        private IEnumerable<Type> GetHandlerTypes<T>() where T : Command
        {
            IEnumerable<Type> types =
               from a in AppDomain.CurrentDomain.GetAssemblies()
               from t in a.GetTypes()
               select t;  
            var handlers = types
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                    .Where(h => h.GetInterfaces()
                        .Any(ii => ii.GetGenericArguments()
                            .Any(aa => aa == typeof(T)))).ToList();


            return handlers;
        }

    }
}
