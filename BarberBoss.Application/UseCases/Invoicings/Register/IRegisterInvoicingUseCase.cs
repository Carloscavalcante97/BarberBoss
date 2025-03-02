using BarberBoss.Communication.Request;
using BarberBoss.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss.Application.UseCases.Invoicings.Register
{
    public interface IRegisterInvoicingUseCase
    {
        Task<ResponseInvoicingJson> Execute (RequestInvoicingJson request);
    }
}
