using Data.Repositories;
using Domain.UseCases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Domain.Interfaces.UseCases;
using Domain.Interfaces.Repositories;

namespace CompositionRoot
{
    public static class Container
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            // Aquí se registran las dependencias entre capas
            // Ejemplo:
            services.AddScoped<IRepoPersona, RepositoryPersonas>();
            services.AddScoped<IUseCasePersona, UseCase>();
            return services;
        }
    }
}
