using Microsoft.Extensions.DependencyInjection;
using University.DAL.Repositories.Contracts;
using University.DAL.Repositories;

namespace University.DAL
{
    public static class DataAccessLayerServiceRegistration
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));

            return services;
        }
    }
}
