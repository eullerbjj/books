using Books.API.Filters;
using Books.API.Request.Subject;
using Books.API.Response;
using Books.Application.UseCases.Subject.Create;
using Books.Application.UseCases.Subject.Delete;
using Books.Application.UseCases.Subject.GetAll;
using Books.Application.UseCases.Subject.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("subjects")]
    [ServiceFilter(typeof(ExceptionFilter))]
    public class SubjectController : Controller
    {
        private readonly IMediator _mediator;

        public SubjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] CreateSubjectRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send((CreateCommand)request);
            
            return Created();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateSubjectRequest request)
        {
            await _mediator.Send(UpdateSubjectRequest.ToCommand(id, request));

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

            return Ok((SubjectResponse)result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllQuery();

            var result = await _mediator.Send(query);

            return Ok(result.Subjects.Select(subject => (SubjectResponse)subject).ToList());
        }
    }
}
