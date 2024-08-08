using PruebaIngresoBibliotecario.UseCasesDTOs.GetLoanById;

namespace PruebaIngresoBibliotecario.UseCasesPorts.GetLoanById
{
    public interface IGetLoanByIdOutputPort
    {
        Task Handle(GetLoanByIdDTO loanByIdDTO);
    }
}
