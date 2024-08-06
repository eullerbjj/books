using Books.API.Filters;
using Books.API.Request.Author;
using Books.API.Response;
using Books.Application.UseCases.Author.Create;
using Books.Application.UseCases.Author.Delete;
using Books.Application.UseCases.Author.GetAll;
using Books.Application.UseCases.Author.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("authors")]
    [ServiceFilter(typeof(ExceptionFilter))]
    public class AuthorController : Controller
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] CreateAuthorRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send((CreateCommand)request);
            
            return Created();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateAuthorRequest request)
        {
            await _mediator.Send(UpdateAuthorRequest.ToCommand(id, request));

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

            return Ok((AuthorResponse)result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllQuery();

            var result = await _mediator.Send(query);

            return Ok(result.Authors.Select(author => (AuthorResponse)author).ToList());
        }
    }
}
