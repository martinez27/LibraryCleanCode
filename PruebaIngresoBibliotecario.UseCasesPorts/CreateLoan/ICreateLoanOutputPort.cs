namespace PruebaIngresoBibliotecario.UseCasesPorts.CreateLoan
{
    public interface ICreateLoanOutputPort
    {
        Task Handle(Guid id, DateTime maxReturnDate);
    }
}
