using BarberBoss.Application.UseCases.Invoicings.Register;
using BarberBoss.Communication.Request;
using BarberBoss.Communication.Responses;
using BarberBoss.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class invoicingController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseInvoicingJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterInvoicingUseCase useCase,
            [FromBody] RequestInvoicingJson request)
        {
            try
            {
                var response = await useCase.Execute(request);
                return Created(string.Empty, response);

            }
            catch (ErrorOnValidationException ex)
            {
                return BadRequest(new {errors = ex.GetErrors()});
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
    }
}