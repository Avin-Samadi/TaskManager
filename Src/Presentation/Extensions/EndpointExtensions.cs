using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Presentation.Properties.Contracts;

namespace Presentation.Extensions
{
    public static class EndpointExtensions
    {
        public static IServiceCollection AddEndpoints(
            this IServiceCollection services,
            Assembly assembly
        )
        {
            var serviceDescriptors = assembly
                .GetTypes()
                .Where(t => t.IsClass && t.IsAssignableTo(typeof(IEndpoint)))
                .Select(endpointType =>
                    ServiceDescriptor.Transient(typeof(IEndpoint), endpointType)
                );

            services.TryAddEnumerable(serviceDescriptors);

            return services;
        }

        public static WebApplication MapEndpoints(this WebApplication app)
        {
            var endpoints = app.Services.GetServices<IEndpoint>();

            foreach (var endpoint in endpoints)
            {
                endpoint.MapEndpoint(app);
            }

            return app;
        }
    }
}
