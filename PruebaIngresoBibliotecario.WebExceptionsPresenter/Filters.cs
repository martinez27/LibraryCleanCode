using FluentValidation;
using PruebaIngresoBibliotecario.Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace PruebaIngresoBibliotecario.WebExceptionsPresenter
{
    public static class Filters
    {
        public static void Register(MvcOptions options)
        {
            options.Filters.Add(new ApiExceptionFilterAttribute(
                new Dictionary<Type, IExceptionHandler>
                {

                    {
                        typeof(GeneralException), new GeneralExceptionHandle()
                    },
                    {
                        typeof(ValidationException), new ValidationExceptionHandler()
                    },
                    {
                        typeof(BadRequestException), new BadRequestExceptionHandler()
                    },
                    {
                        typeof(NotFoundException), new NotFoundExceptionHandle()
                    }
                }));
        }
    }
}
