using Microsoft.EntityFrameworkCore;
using PruebaIngresoBibliotecario.Entities.POCOEntities;

namespace PruebaIngresoBibliotecario.Repositories.InMemory.Context
{
    public class PersistenceContext : DbContext
    {
        public PersistenceContext(DbContextOptions<PersistenceContext> options) : base(options) { }

        public DbSet<Loan> Loans { get; set; }
    }
}
