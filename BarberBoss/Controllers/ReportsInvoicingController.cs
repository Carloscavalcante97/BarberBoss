using BarberBoss.Application.UseCases.Invoicings.Reports.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BarberBoss.Api.Controllers
{
    public class ReportsInvoicingController : Controller
    {
        [HttpGet("excel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetExcel(
               [FromServices] IGenerateInvoicingReportExcelUseCase useCase,
               [FromHeader] DateOnly month)
        {
            string data = $"{month.Year}/{month.Month}";

            byte[] file = await useCase.Execute(month);

            if (file.Length > 0)
            {
                return File(file, MediaTypeNames.Application.Octet, $"report-{data}.xlsx");
            }

            return NoContent();
        }
    }
}
