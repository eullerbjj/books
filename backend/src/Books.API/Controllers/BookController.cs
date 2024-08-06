using Books.API.Filters;
using Books.API.Request.Book;
using Books.API.Response;
using Books.Application.UseCases.Book.Create;
using Books.Application.UseCases.Book.Delete;
using Books.Application.UseCases.Book.GetAll;
using Books.Application.UseCases.Book.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("books")]
    [ServiceFilter(typeof(ExceptionFilter))]
    public class BookController : Controller
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBookRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send((CreateCommand)request);
            
            return Created();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateBookRequest request)
        {
            await _mediator.Send(UpdateBookRequest.ToCommand(id, request));

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

            return Ok((BookResponse)result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllQuery();

            var result = await _mediator.Send(query);

            return Ok(result.Books.Select(book => (BookResponse)book).ToList());
        }
    }
}
