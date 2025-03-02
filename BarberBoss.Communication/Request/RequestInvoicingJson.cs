using BarberBoss.Communication.Enums;

namespace BarberBoss.Communication.Request
{
    public class RequestInvoicingJson
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime Data { get; set; } = DateTime.UtcNow.AddHours(-3);
        public decimal Preco { get; set; }
        public string? Descricao { get; set; }
        public ServicesType Servico { get; set; }
        public PaymentType payment { get; set; }
    }
}
