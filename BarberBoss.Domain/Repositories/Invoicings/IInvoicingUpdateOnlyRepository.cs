using BarberBoss.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss.Domain.Repositories.Invoicings
{
    public interface IInvoicingUpdateOnlyRepository
    {
        Task<Invoicing?> GetById(long id);
        void Update(Invoicing invoicing);
    }
}
