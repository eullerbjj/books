using Books.API.Filters;
using Books.API.Request.SaleType;
using Books.API.Response;
using Books.Application.UseCases.SaleType.Create;
using Books.Application.UseCases.SaleType.Delete;
using Books.Application.UseCases.SaleType.GetAll;
using Books.Application.UseCases.SaleType.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("saletypes")]
    [ServiceFilter(typeof(ExceptionFilter))]
    public class SaleTypeController : Controller
    {
        private readonly IMediator _mediator;

        public SaleTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] CreateSaleTypeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send((CreateCommand)request);
            
            return Created();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateSaleTypeRequest request)
        {
            await _mediator.Send(UpdateSaleTypeRequest.ToCommand(id, request));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new DeleteCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetByIdQuery(id);

            var result = await _mediator.Send(query);

            return Ok((SaleTypeResponse)result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllQuery();

            var result = await _mediator.Send(query);

            return Ok(result.SaleTypes.Select(saletype => (SaleTypeResponse)saletype).ToList());
        }
    }
}
