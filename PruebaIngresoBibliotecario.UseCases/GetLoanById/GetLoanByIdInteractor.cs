using FluentValidation.Results;
using PruebaIngresoBibliotecario.Entities.Exceptions;
using PruebaIngresoBibliotecario.Entities.Inteface;
using PruebaIngresoBibliotecario.Entities.POCOEntities;
using PruebaIngresoBibliotecario.UseCases.Utils;
using PruebaIngresoBibliotecario.UseCasesDTOs.GetLoanById;
using PruebaIngresoBibliotecario.UseCasesPorts.CreateLoan;
using PruebaIngresoBibliotecario.UseCasesPorts.GetLoanById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.UseCases.GetLoanById
{
    public class GetLoanByIdInteractor : IGetLoanByIdInputPort
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetLoanByIdOutputPort _outputPort;
        private readonly GuidValidator _guidValidator;

        public GetLoanByIdInteractor(ILoanRepository loanRepository, IUnitOfWork unitOfWork, IGetLoanByIdOutputPort outputPort, GuidValidator guidValidator)
        {
            _loanRepository = loanRepository;
            _unitOfWork = unitOfWork;
            _outputPort = outputPort;
            _guidValidator = guidValidator;
        }

        public async Task Handle(string id)
        {
            ValidationResult result = _guidValidator.Validate(id);

            if (!result.IsValid)
                throw new BadRequestException(result.Errors.First().ErrorMessage);

            Loan loan = await _loanRepository.GetLoanById(Guid.Parse(id));

            if (loan == null)
                throw new NotFoundException($"El prestamo con id {id} no existe");

            var loanByIdDTO = new GetLoanByIdDTO
            {
                Id = loan.Id,
                Isbn = loan.Isbn,
                IdentificacionUsuario = loan.IdentificacionUsuario,
                TipoUsuario = (int)loan.TipoUsuario,
                FechaMaximaDevolucion = loan.FechaDevolucionPrestamoLibro
            };

            await _outputPort.Handle(loanByIdDTO);

        }
    }
}
