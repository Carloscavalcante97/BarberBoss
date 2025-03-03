namespace BarberBoss.Application.UseCases.Invoicings.Reports
{
    public interface IGenerateInvoicingReportExcelUseCase
    {
        Task<byte[]> Execute(DateOnly month);
    }
}
