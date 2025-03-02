using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories.Invoicings
{
    public interface IInvoicingWriteOnlyRepository
    {
        /// <summary>
        /// This method add a new invoicing.
        /// </summary>
        /// <param name="invoicing"></param>
        /// <returns></returns>
        Task Add(Invoicing invoicing);
    }
}
