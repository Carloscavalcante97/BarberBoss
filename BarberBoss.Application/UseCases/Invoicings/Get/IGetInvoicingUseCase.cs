using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.Invoicings.Get
{
    public interface IGetInvoicingUseCase
    {
        Task<RequestInvoicingsJson> Execute();
    }
}
