using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using PruebaIngresoBibliotecario.Entities.Exceptions;

namespace PruebaIngresoBibliotecario.WebExceptionsPresenter
{
    public class NotFoundExceptionHandle : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            var exception = context.Exception as NotFoundException;
            return SetResult(context, StatusCodes.Status404NotFound, exception.Message);
        }
    }
}
