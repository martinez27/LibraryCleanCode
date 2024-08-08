using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.WebExceptionsPresenter
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, IExceptionHandler> _exceptionHandlers;

        public ApiExceptionFilterAttribute(IDictionary<Type, IExceptionHandler> exceptionHandlers)
        {
            _exceptionHandlers = exceptionHandlers;
        }

        public override void OnException(ExceptionContext context)
        {
            Type exceptionType = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(exceptionType))
            {
                _exceptionHandlers[exceptionType].Handle(context);
            }
            else 
            {
                //exception Base

                new ExceptionHandlerBase().SetResult(context, StatusCodes.Status500InternalServerError, "Ha ocurrido un error al procesar la respuesta del servidor");

            }
            base.OnException(context);
        }
    }
}
