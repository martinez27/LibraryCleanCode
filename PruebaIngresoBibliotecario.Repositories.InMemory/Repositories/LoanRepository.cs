using Microsoft.EntityFrameworkCore;
using PruebaIngresoBibliotecario.Entities.Inteface;
using PruebaIngresoBibliotecario.Entities.POCOEntities;
using PruebaIngresoBibliotecario.Repositories.InMemory.Context;
using System.Linq.Expressions;

namespace PruebaIngresoBibliotecario.Repositories.InMemory.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly PersistenceContext _context;

        public LoanRepository(PersistenceContext context)
        {
            _context = context;
        }

        public Task CreateLoan(Loan loan)
        {
            if (loan == null)
            {
                throw new ArgumentNullException(nameof(loan));
            }

            return Task.FromResult(_context.Add(loan));
        }

        public async Task<Loan> GetLoanById(Guid id)
        {
            return await _context.Loans.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<IEnumerable<Loan>> GetAll(Expression<Func<Loan, bool>> expression)
        {
            var predicate = expression.Compile();
            return Task.FromResult(_context.Loans.Where(predicate));

        }
    }
}
