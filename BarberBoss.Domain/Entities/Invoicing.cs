using BarberBoss.Communication.Enums;

namespace BarberBoss.Domain.Entities
{
    public class Invoicing
    {
        public long Id { get; set; }
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? Data { get; set; } = DateTime.UtcNow.AddHours(-3);
        public decimal Preco { get; set; }
        public ServicesType Servico { get; set; }
        public PaymentType TipoPagamento { get; set; }
    }
}
