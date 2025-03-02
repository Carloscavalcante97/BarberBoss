using BarberBoss.Application.AutoMapper;
using BarberBoss.Application.UseCases.Invoicings.Register;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterInvoicingUseCase, RegisterInvoicingUseCase>();
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
           services.AddAutoMapper(typeof(AutoMapping));    
        }
    }
}
