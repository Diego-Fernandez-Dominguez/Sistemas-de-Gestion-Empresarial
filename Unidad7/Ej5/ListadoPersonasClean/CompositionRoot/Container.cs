using Data.Repositories;
using Domain.Interfaces;
using Domain.UseCases;
using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace CompositionRoot
{
    public static class Container
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            // Aquí se registran las dependencias entre capas
            // Ejemplo:
            services.AddScoped<IGetListaPersonas, PersonasRepositoryAzure>();
            services.AddScoped<IGetListaPersonasUseCases, GetListaPersonasUseCase>();
            return services;
        }
    }
}
