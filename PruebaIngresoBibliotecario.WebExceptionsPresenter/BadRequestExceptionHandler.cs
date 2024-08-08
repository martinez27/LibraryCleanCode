using PruebaIngresoBibliotecario.Entities.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.WebExceptionsPresenter
{
    public class BadRequestExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            var exception = context.Exception as BadRequestException;

            return SetResult(context, StatusCodes.Status400BadRequest, exception.Message);
        }
    }
}
