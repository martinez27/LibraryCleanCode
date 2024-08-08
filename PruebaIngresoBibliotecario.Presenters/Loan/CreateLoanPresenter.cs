using PruebaIngresoBibliotecario.UseCasesPorts.CreateLoan;

namespace PruebaIngresoBibliotecario.Presenters.Loan
{
    public class CreateLoanPresenter : ICreateLoanOutputPort
    {
        public object Content { get; private set; }
        public Task Handle(Guid id, DateTime maxReturnDate)
        {
            Content = new
            { 
                id,
                fechaMaximaDevolucion = maxReturnDate.ToString("dd/MM/yyyy"),
                //fechaMaximaDevolucion = maxReturnDate.ToString("MM/dd/yyyy"),
            };

            //Content = $"El prestamo con id: {id} tiene como fecha máxima {maxReturnDate:dd-MM-YYYY}";
            return Task.CompletedTask;
        }
    }
}
