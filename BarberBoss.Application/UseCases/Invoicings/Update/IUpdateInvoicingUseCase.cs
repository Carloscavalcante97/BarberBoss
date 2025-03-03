using BarberBoss.Communication.Request;

namespace BarberBoss.Application.UseCases.Invoicings.Update
{
    public interface IUpdateInvoicingUseCase
    {
        Task Execute(long id, RequestInvoicingJson request);
    }
}
