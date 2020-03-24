using System.Collections.Generic;
using TauCode.Cqrs.Mq;
using TauCode.WebApi.Testing.Tests.AppHost.AppDomainEventConverters.NestedConverters;

namespace TauCode.WebApi.Testing.Tests.AppHost.AppDomainEventConverters
{
    public class DomainEventConverter : MultiDomainEventConverter
    {
        public DomainEventConverter()
            : base(new List<IDomainEventConverter>
            {
                new CurrencyCreatedDomainEventConverter()
            })
        {
        }
    }
}
