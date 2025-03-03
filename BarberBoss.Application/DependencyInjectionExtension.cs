using BarberBoss.Application.AutoMapper;
using BarberBoss.Application.UseCases.Invoicings.Delete;
using BarberBoss.Application.UseCases.Invoicings.Get;
using BarberBoss.Application.UseCases.Invoicings.Register;
using BarberBoss.Application.UseCases.Invoicings.Reports;
using BarberBoss.Application.UseCases.Invoicings.Update;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IGetInvoicingUseCase, GetInvoicingUseCase>();
            services.AddScoped<IDeleteInvoicingsUseCase, DeleteInvoicingsUseCase>();
            services.AddScoped<IUpdateInvoicingUseCase, UpdateInvoicingUseCase>();
            services.AddScoped<IGenerateInvoicingReportExcelUseCase, GenerateInvoicingReportExcelUseCase>();
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
           services.AddAutoMapper(typeof(AutoMapping));    
        }
    }
}
