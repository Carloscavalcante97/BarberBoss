using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss.Application.UseCases.Invoicings.Delete
{
    public interface IDeleteInvoicingsUseCase
    {
        Task Execute(long id);
    }
}
