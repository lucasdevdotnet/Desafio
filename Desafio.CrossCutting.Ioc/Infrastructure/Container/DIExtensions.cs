using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Desafio.CrossCutting.Ioc.Infrastructure.Container
{
    [ExcludeFromCodeCoverage]
    public static class DIExtensions
    {
        public static IServiceCollection AddExportedServicesFromAssemblyContaining<T>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            var types = typeof(T).Assembly.GetExportedTypes();
            foreach (var type in types)
            {
                if (!type.IsClass || type.IsAbstract)
                    continue;
                var interfaces = type.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    var serviceType = GetServiceType(type, @interface);
                    if (serviceType == null)
                        continue;
                    services.TryAdd(new ServiceDescriptor(serviceType, type, lifetime));
                }
            }
            return services;
        }

        private static Type? GetServiceType(Type implementationType, Type serviceType)
        {
            Type? adjustedServiceType;
            if (serviceType.IsGenericTypeDefinition)
            {
                if (!implementationType.IsGenericTypeDefinition)
                    return null;
                adjustedServiceType = serviceType;
            }
            else
            {
                if (implementationType.IsGenericTypeDefinition)
                {
                    if (!serviceType.IsGenericType)
                        return null;
                    else
                        adjustedServiceType = serviceType.GetGenericTypeDefinition();
                }
                else
                {
                    adjustedServiceType = serviceType;
                }
            }
            return adjustedServiceType;
        }
    }
}