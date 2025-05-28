using Application;
using Application.Contracts;
using Domain.Contracts;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddTransient<IIdGenerator<Guid>, GuidGenerator>();
            services.AddTransient<ITaskTypeRepository, TaskTypeRepository>();
            services.AddTransient<ITaskTypeManager, TaskTypeManager>();

            services.AddDbContextPool<TaskManagerContext>(builder =>
            {
                builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}
