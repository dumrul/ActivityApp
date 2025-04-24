using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ETAP.Application.Interfaces;
using ETAP.Application.Services.Activities;

namespace ETAP.Application.ServiceRegistration
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // AutoMapper profil taraması
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // FluentValidation taraması
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<IActivityService, ActivityService>();
            
            return services;
        }
    }
}