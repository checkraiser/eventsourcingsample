using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore
{
    public class AggregateNotFoundException : Exception
    {
        public AggregateNotFoundException(string message) : base(message) { }
    }
    public class ConcurrencyException : Exception
    {
        public ConcurrencyException(string message) : base(message) { }
    }
    public class UnregisteredDomainCommandException : Exception
    {
        public UnregisteredDomainCommandException(string message) : base(message) { }
    }
    public class UnregisteredDomainEventException : Exception
    {
        public UnregisteredDomainEventException(string message) : base(message) { }
    }
}
