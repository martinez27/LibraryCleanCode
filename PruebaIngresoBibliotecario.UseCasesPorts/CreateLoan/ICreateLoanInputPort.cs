using PruebaIngresoBibliotecario.UseCasesDTOs.CreateLoan;

namespace PruebaIngresoBibliotecario.UseCasesPorts.CreateLoan
{
    public interface ICreateLoanInputPort
    {
        Task Handle(CreateLoanParameters parameters);
    }
}
