using Domain.Interfaces.RepositoriesInterface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompositionRoot
{
    public static class DI
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepositoryMision, MisionesRepository>();
            return services;
        }
    }
}
