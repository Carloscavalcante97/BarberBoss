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
        /// <summary>
        /// This method delete a invoicing.
        /// </summary>
        /// <param name="invoicing"></param>
        /// <returns></returns>
        Task<bool> Delete(long id);
        /// <summary>
        /// This method update a invoicing.
        /// </summary>
        /// <param name="invoicing"></param>
        /// <returns></returns>
    }
}
