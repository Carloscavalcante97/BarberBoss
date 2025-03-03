using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Invoicings;
using BarberBoss.infrastructure.DataAccess;
using BarberBoss.infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BarberBoss.infrastructure
{
    public static class DependencyInjectionExtensios
    {
        public static void AddInfrasctruture(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);
            AddDbContext(services, configuration);
        }
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IInvoicingWriteOnlyRepository, InvoicingRepository>();           
            services.AddScoped<IInvoicingReadOnlyRepository, InvoicingRepository>();
            services.AddScoped<IInvoicingUpdateOnlyRepository, InvoicingRepository>();

        }
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 40));
            services.AddDbContext<BarberBossDbContext>(config => config.UseMySql(connectionString, serverVersion));
        }
    }
}
