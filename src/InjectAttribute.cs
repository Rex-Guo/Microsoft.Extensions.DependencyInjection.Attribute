
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple=true,Inherited=false)]
    public class InjectAttribute:Attribute
    {
        public InjectAttribute(ServiceLifetime serviceLifetime, Type implementType =null)
        {
            ServiceLifetime = serviceLifetime;
            ImplementType = implementType;
        }

        public ServiceLifetime ServiceLifetime { get; private set; }

        public Type ImplementType { get;private set; }
    }
}
