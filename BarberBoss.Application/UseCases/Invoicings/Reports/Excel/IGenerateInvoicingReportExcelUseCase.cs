namespace BarberBoss.Application.UseCases.Invoicings.Reports.Excel
{
    public interface IGenerateInvoicingReportExcelUseCase
    {
        Task<byte[]> Execute(DateOnly month);
    }
}
