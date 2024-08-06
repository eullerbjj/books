using Books.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Books.API.Filters
{
    public sealed class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case NotFoundException:
                    context.Result = new NotFoundResult();
                    break;
                
                default:

                    var error = new ErrorModel
                    (
                        500,
                        context.Exception.Message,
                        context.Exception.StackTrace?.ToString()
                    );

                    context.Result = new ObjectResult(error)
                    {
                        StatusCode = (int)HttpStatusCode.InternalServerError
                    };

                    break;
            }   
        }
    }
}
