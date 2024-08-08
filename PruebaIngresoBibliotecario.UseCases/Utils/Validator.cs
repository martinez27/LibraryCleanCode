using FluentValidation;
using FluentValidation.Results;

namespace PruebaIngresoBibliotecario.UseCases.Utils
{
    public static class Validator<TModel>
    {
        public static Task<List<ValidationFailure>> Validations(TModel instance,
            IEnumerable<IValidator<TModel>> validators, bool causeException = true)
        {
            List<ValidationFailure> errors = validators
                .Select(x => x.Validate(instance))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .ToList();

            if (errors.Any() && causeException)
                throw new ValidationException(errors);

            return Task.FromResult(errors);
        }
    }
}
