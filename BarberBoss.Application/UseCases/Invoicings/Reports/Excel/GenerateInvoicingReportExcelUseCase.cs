using BarberBoss.Application.UseCases.Invoicings.Reports.Excel;
using BarberBoss.Domain.Enums;
using BarberBoss.Domain.Repositories.Invoicings;
using ClosedXML.Excel;

namespace BarberBoss.Application.UseCases.Invoicings.Reports
{
    public class GenerateInvoicingReportExcelUseCase : IGenerateInvoicingReportExcelUseCase
    {
        private const string CURRENCY_SYMBOL = "$";
        private readonly IInvoicingReadOnlyRepository _repository;
        public GenerateInvoicingReportExcelUseCase(IInvoicingReadOnlyRepository repository)
        {
            _repository = repository;
        }
        public async Task<byte[]> Execute(DateOnly month)
        {
           var invoicings = await _repository.GetByMonth(month);
            if(invoicings.Count == 0)
            {
                return [];
            }
            using var workbook = new XLWorkbook();
            workbook.Author = "Antônio Cavalcante";
            workbook.Style.Font.FontSize = 12;
            workbook.Style.Font.FontName = "Times New Roman";
            var worksheet = workbook.Worksheets.Add(month.ToString("Y"));
            InsertHeader(worksheet);
            decimal expensesSum = 0;
            var raw = 2;
            foreach (var invoicing in invoicings)
            {
                worksheet.Cell($"A{raw}").Value = invoicing.Nome;
                worksheet.Cell($"B{raw}").Value = invoicing.Servico.TipoServicoToString();
                worksheet.Cell($"C{raw}").Value = invoicing.Data?.ToString("dd/MM/yyyy") ?? string.Empty;
                worksheet.Cell($"D{raw}").Value = invoicing.Descricao;
                worksheet.Cell($"E{raw}").Value = invoicing.TipoPagamento.TipoPagamentoToString();
                worksheet.Cell($"F{raw}").Value = $"{CURRENCY_SYMBOL} -{invoicing.Preco}";
                expensesSum += invoicing.Preco;
                raw++;
            }
            worksheet.Cell("G2").Value = expensesSum;
            worksheet.Cell("G2").Style.NumberFormat.Format = $"-{CURRENCY_SYMBOL} #,##0.00";
            
            worksheet.Columns().AdjustToContents();
            
            var file = new MemoryStream();
            
            workbook.SaveAs(file);

            return file.ToArray();

        }
        private void InsertHeader(IXLWorksheet worksheet)
        {
            
            worksheet.Cell("A1").Value = "Cliente";
            worksheet.Cell("B1").Value = "Serviço";
            worksheet.Cell("C1").Value = "Data";
            worksheet.Cell("D1").Value = "Descrição";
            worksheet.Cell("E1").Value = "Forma de pagamento";
            worksheet.Cell("F1").Value = "Valor";
            worksheet.Cell("G1").Value = "Total";
            worksheet.Cells("A1:G1").Style.Font.Bold = true;
            worksheet.Cells("A1:G1").Style.Fill.BackgroundColor = XLColor.ArmyGreen;
            worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("F1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
            worksheet.Cell("G1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        }
    }
}
