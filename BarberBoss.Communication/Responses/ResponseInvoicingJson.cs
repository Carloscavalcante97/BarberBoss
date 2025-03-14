﻿using BarberBoss.Communication.Enums;

namespace BarberBoss.Communication.Responses
{
    public class ResponseInvoicingJson
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public ServicesType Servico { get; set; }
        public PaymentType payment { get; set; }
    }
}
