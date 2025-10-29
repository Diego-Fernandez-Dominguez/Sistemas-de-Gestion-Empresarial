using Microsoft.Extensions.DependencyInjection;
using Data.Repositories;
using Domain.Interfaces;
using Domain.UseCases;
using Domain.Repositories;

namespace CompositionRoot
{
    public static class Container
    {
        public static IServiceProvider AddCompositionRoot(this IServiceCollection services)
        {
            // Aquí se registran las dependencias entre capas
            // Ejemplo:
            services.AddScoped<IGetListaPersonas, RepositoryPersonas>();
            services.AddScoped<IGetListaPersonasUseCases, GetListaPersonasUseCase>();
            return services.BuildServiceProvider();
        }
    }
}
