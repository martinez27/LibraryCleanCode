using FluentValidation;

namespace PruebaIngresoBibliotecario.UseCases.Utils
{
    public class GuidValidator : AbstractValidator<string>
    {
        public GuidValidator()
        {
            RuleFor(value => value)
                .Must(BeAValidadGuid).WithMessage("La propiedad debe ser un Guid valido");
        }

        private bool BeAValidadGuid(string? input)
        {
            return Guid.TryParse(input, out _);
        }
    }
}
