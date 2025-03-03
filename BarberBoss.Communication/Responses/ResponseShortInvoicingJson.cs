using BarberBoss.Communication.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss.Communication.Responses
{
    public class ResponseShortInvoicingJson
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public ServicesType Servico { get; set; }
        public PaymentType payment { get; set; }
    }
}
