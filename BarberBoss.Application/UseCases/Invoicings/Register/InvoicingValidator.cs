using BarberBoss.Communication.Request;
using BarberBoss.Exception;
using FluentValidation;

namespace BarberBoss.Application.UseCases.Invoicings.Register
{
    public class InvoicingValidator : AbstractValidator<RequestInvoicingJson>
    {
        public InvoicingValidator()
        {
            RuleFor(invoicings => invoicings.Nome).NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);
            RuleFor(invoicings => invoicings.Preco).GreaterThan(0).WithMessage(ResourceErrorMessages.GREATER_THAN_0);
            RuleFor(invoicings => invoicings.Data).LessThan(DateTime.Now).WithMessage(ResourceErrorMessages.DATE_ERROR);
            RuleFor(Invoicings => Invoicings.Servico).IsInEnum().WithMessage(ResourceErrorMessages.SERVICETYPE_ERROR);
            RuleFor(Invoicings => Invoicings.payment).IsInEnum().WithMessage(ResourceErrorMessages.PAYMENTTYPE_ERROR);
        }
    }
}