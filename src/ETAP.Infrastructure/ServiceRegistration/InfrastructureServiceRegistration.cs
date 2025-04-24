
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using ETAP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ETAP.Infrastructure.ServiceRegistration
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Connection string'i appsettings.json'dan al
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EtapDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(EtapDbContext).Assembly.FullName);
                });
            });

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IReadRepositoryBase<>), typeof(RepositoryBase<>));

            // İleride başka altyapı servisleri buraya eklenebilir (örneğin e-posta, dosya sistemi vs.)

            return services;
        }

    }
}