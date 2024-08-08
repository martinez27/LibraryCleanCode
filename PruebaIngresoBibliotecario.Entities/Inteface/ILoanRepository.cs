using PruebaIngresoBibliotecario.Entities.POCOEntities;
using System.Linq.Expressions;

namespace PruebaIngresoBibliotecario.Entities.Inteface
{
    public interface ILoanRepository
    {
        Task CreateLoan(Loan loan);
        Task<Loan> GetLoanById(Guid id);
        Task <IEnumerable<Loan>> GetAll(Expression<Func<Loan,bool>> expression);
    }
}
