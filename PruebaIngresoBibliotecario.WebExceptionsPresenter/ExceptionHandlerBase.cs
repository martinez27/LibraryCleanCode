using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PruebaIngresoBibliotecario.WebExceptionsPresenter
{
    public class ExceptionHandlerBase
    {
        public Task SetResult(ExceptionContext context, int? status, string mensaje)
        {
            context.Result = new ObjectResult(new { mensaje })
            { 
                StatusCode = status
            };

            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}
