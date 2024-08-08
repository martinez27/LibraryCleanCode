using Microsoft.AspNetCore.Mvc.Filters;

namespace PruebaIngresoBibliotecario.WebExceptionsPresenter
{
    public interface IExceptionHandler
    {
        Task Handle(ExceptionContext context);
    }
}
