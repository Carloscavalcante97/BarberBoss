using BarberBoss.Communication.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss.Domain.Enums
{
    public static class TipoPagamentoExtension
    {
        public static string TipoPagamentoToString(this PaymentType payment)
        {
            return payment switch
            {
                PaymentType.Dinheiro => "Dinheiro",
                PaymentType.Credito => "Cartão de crédito",
                PaymentType.Debito => "Cartão de débito",
                PaymentType.Pix => "Pix",
                PaymentType.Boleto => "Boleto",
                _ => string.Empty

            };
        }
    }
}
