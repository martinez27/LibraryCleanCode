using FluentValidation;
using PruebaIngresoBibliotecario.Entities.Enums;
using PruebaIngresoBibliotecario.UseCasesDTOs.CreateLoan;

namespace PruebaIngresoBibliotecario.UseCases.CreateLoan
{
    public class CreateLoanValidator : AbstractValidator<CreateLoanParameters>
    {
        public CreateLoanValidator()
        {
            RuleFor(x => x.Isbn)
                .NotEmpty().WithMessage("Debe proporcionar el ID del libro")
                .Must(BeAValidadGuid).WithMessage("La propiedad debe ser un Guid valido");
            RuleFor(x => x.IdentificacionUsuario)
                .NotEmpty().WithMessage("Debe proporcionar el Identificador del usuario")
                .MaximumLength(10).WithMessage("Debe contener máximo 10 caracteres");
            RuleFor(x => x.TipoUsuario)
                .NotEmpty().WithMessage("Debe proporcionar el tipo de usuario")
                .Must(BeAValidEnumValue).WithMessage("La propiedad debe ser un valor válido de tipo de usuario");                

        }

        private bool BeAValidadGuid(string? input)
        {
            return Guid.TryParse(input, out _);
        }

        private bool BeAValidEnumValue(int input)
        {
            return Enum.IsDefined(typeof(TipoUsuario), input);
        }
    }
}
