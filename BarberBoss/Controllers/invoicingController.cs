using BarberBoss.Application.UseCases.Invoicings.Delete;
using BarberBoss.Application.UseCases.Invoicings.Get;
using BarberBoss.Application.UseCases.Invoicings.Register;
using BarberBoss.Application.UseCases.Invoicings.Update;
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
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
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
                return BadRequest(new { errors = ex.GetErrors() });
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(ResponseInvoicingJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(
            [FromServices] IGetInvoicingUseCase useCase)
        {
            try
            {
                var response = await useCase.Execute();
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
            [FromServices] IDeleteInvoicingsUseCase useCase,
            [FromRoute] long id)
        {
            try
            {
                await useCase.Execute(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { errors = ex.GetErrors() });
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
            [FromServices] IUpdateInvoicingUseCase useCase,
            [FromRoute] long id,
            [FromBody] RequestInvoicingJson request)
        {
            try
            {
                await useCase.Execute(id, request);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { errors = ex.GetErrors() });
            }
            catch (ErrorOnValidationException ex)
            {
                return BadRequest(new { errors = ex.GetErrors() });
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}