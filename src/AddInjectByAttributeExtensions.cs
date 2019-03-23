using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AddInjectByAttributeExtensions
    {
        public static IServiceCollection AddInject(this IServiceCollection services,params Assembly[] assemblies)
        {
            var types = assemblies.SelectMany(s => s.GetTypes()).Distinct();
            var injectAtrributeType=typeof(InjectAttribute);
            var registedTypes = types.Where(w => w.CustomAttributes.Any(a => a.AttributeType == injectAtrributeType));

            foreach (var item in registedTypes)
            {
                var att = (InjectAttribute)item.GetCustomAttribute(injectAtrributeType, false);
                var serviceDescriptor = default(ServiceDescriptor);

                if (att.ImplementType != null)
                {
                    var type = types.First(f => f.GUID == att.ImplementType.GUID);
                    serviceDescriptor = new ServiceDescriptor(type, item, att.ServiceLifetime);
                }
                else
                {
                    serviceDescriptor = new ServiceDescriptor(item, att.ServiceLifetime);
                }

                services.Add(serviceDescriptor);
            }

            return services;
        }
    }
}
