using Microsoft.AspNetCore.Mvc;
using PruebaIngresoBibliotecario.Presenters.Loan;
using PruebaIngresoBibliotecario.UseCasesDTOs.CreateLoan;
using PruebaIngresoBibliotecario.UseCasesDTOs.GetLoanById;
using PruebaIngresoBibliotecario.UseCasesPorts.CreateLoan;
using PruebaIngresoBibliotecario.UseCasesPorts.GetLoanById;

namespace PruebaIngresoBibliotecario.Controllers
{
    [Route("api/prestamo")]
    [ApiController]
    public class LoanController
    {
        private readonly ICreateLoanInputPort _createLoanInputPort;
        private readonly ICreateLoanOutputPort _createLoanOutputPort;

        private readonly IGetLoanByIdInputPort _getLoanByIdInputPort;
        private readonly IGetLoanByIdOutputPort _getLoanByIdOutputPort;

        public LoanController(ICreateLoanInputPort createLoanInputPort, ICreateLoanOutputPort createLoanOutputPort, IGetLoanByIdInputPort getLoanByIdInputPort, IGetLoanByIdOutputPort getLoanByIdOutputPort)
        {
            _createLoanInputPort = createLoanInputPort;
            _createLoanOutputPort = createLoanOutputPort;
            _getLoanByIdInputPort = getLoanByIdInputPort;
            _getLoanByIdOutputPort = getLoanByIdOutputPort;
        }

        [HttpGet("{idPrestamo}")]
        public async Task<GetLoanByIdDTO> GetLoanById(string idPrestamo)
        {
            await _getLoanByIdInputPort.Handle(idPrestamo);

            var presenter = _getLoanByIdOutputPort as GetLoanByIdPresenter;

            return presenter.Content;
        }

        [HttpPost]
        public async Task<object> CreateLoan(CreateLoanParameters parameters)
        {
            //manejar entrada
            await _createLoanInputPort.Handle(parameters);

            //manejar la informacion
            var presenter = _createLoanOutputPort as CreateLoanPresenter;

            //retornar datos
            return presenter.Content;

        }
    }
}