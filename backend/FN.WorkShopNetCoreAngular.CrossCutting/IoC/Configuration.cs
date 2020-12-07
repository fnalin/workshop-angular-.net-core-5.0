using Microsoft.Extensions.DependencyInjection;

namespace FN.WorkShopNetCoreAngular.CrossCutting.IoC
{
    public class Configuration {

        public static void RegisterServices(IServiceCollection services)
        {
            registerData(services);

        }

        private static void registerData(IServiceCollection services)
        {
            services.AddScoped<Data.EF.WorkShopAngularNetCoreDataContext>();
            services.AddTransient<Domain.Contracts.Infra.IUnitOfWork, Data.EF.UnitOfWork>();

            services.AddTransient<Domain.Contracts.Repositories.IClienteRepository, Data.EF.Repositories.CLienteRepositoryEF>();
        }
    }
}