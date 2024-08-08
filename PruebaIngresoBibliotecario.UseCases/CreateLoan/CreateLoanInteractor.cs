using FluentValidation;
using PruebaIngresoBibliotecario.Entities.Enums;
using PruebaIngresoBibliotecario.Entities.Exceptions;
using PruebaIngresoBibliotecario.Entities.Inteface;
using PruebaIngresoBibliotecario.Entities.POCOEntities;
using PruebaIngresoBibliotecario.UseCases.Utils;
using PruebaIngresoBibliotecario.UseCasesDTOs.CreateLoan;
using PruebaIngresoBibliotecario.UseCasesPorts.CreateLoan;

namespace PruebaIngresoBibliotecario.UseCases.CreateLoan
{
    public class CreateLoanInteractor : ICreateLoanInputPort
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICreateLoanOutputPort _outputPort;
        private readonly IEnumerable<IValidator<CreateLoanParameters>> _validators;

        public CreateLoanInteractor(ILoanRepository loanRepository, IUnitOfWork unitOfWork, ICreateLoanOutputPort outputPort, IEnumerable<IValidator<CreateLoanParameters>> validators)
        {
            _loanRepository = loanRepository;
            _unitOfWork = unitOfWork;
            _outputPort = outputPort;
            _validators = validators;
        }

        public async Task Handle(CreateLoanParameters parameters)
        {
            await Validator<CreateLoanParameters>.Validations(parameters,_validators);

            // Si el tipo de usuario es Invitado, consultar prestamos que tenga vigente. Si tiene lanzo Exception si no registro el prestamo
            if (parameters.TipoUsuario == (int)TipoUsuario.INVITADO)
            {
                IEnumerable<Loan> loans = await _loanRepository.GetAll
                    (x => x.TipoUsuario == TipoUsuario.INVITADO && x.IdentificacionUsuario == parameters.IdentificacionUsuario);

                if (loans.Any())
                    throw new BadRequestException($"El usuario con identificacion {parameters.IdentificacionUsuario} ya tiene un libro prestado por lo cual no se le puede realizar otro prestamo");
            }

            // Mapear lso parametros a una entidad

            var loan = new Loan
            {
                Id = Guid.NewGuid(),
                Isbn = Guid.Parse(parameters.Isbn),
                IdentificacionUsuario = parameters.IdentificacionUsuario,
                TipoUsuario = (TipoUsuario)parameters.TipoUsuario
            };

            // Calcular Fecha maxima de Devolucion
            loan.FechaDevolucionPrestamoLibro = GetFechaDevolucionPrestamoLibroForType(loan.TipoUsuario);
            // Crear

            await _loanRepository.CreateLoan(loan);

            //
            try
            {
                // Guardar
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new GeneralException(ex.Message);
            }

            // Manejar Salida
            await _outputPort.Handle(loan.Id, loan.FechaDevolucionPrestamoLibro);

        }

        private static DateTime GetFechaDevolucionPrestamoLibroForType(TipoUsuario TipoUsuario)
        {
            var weekend = new[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
            var fechaDevolucion = DateTime.Now;
            int diasPrestamo = TipoUsuario switch
            {
                TipoUsuario.AFILIADO => 10,
                TipoUsuario.EMPLEADO => 8,
                TipoUsuario.INVITADO => 7,
                _ => -1,
            };

            for (int i = 0; i < diasPrestamo;)
            {
                fechaDevolucion = fechaDevolucion.AddDays(1);
                i = (!weekend.Contains(fechaDevolucion.DayOfWeek)) ? ++i : i;
            }

            return fechaDevolucion;
        }
    }
}