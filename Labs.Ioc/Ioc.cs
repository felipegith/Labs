using Labs.Domain.Interfaces;
using Labs.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Labs.Ioc
{
    public static class Ioc
    {
        public static IServiceCollection Infra(this IServiceCollection services)
        {
            services.AddScoped<IMarkRepository, MarkRepository>();
            
            return services;
        }
    }
}
