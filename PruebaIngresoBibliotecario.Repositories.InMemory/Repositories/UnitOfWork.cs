using PruebaIngresoBibliotecario.Entities.Inteface;
using PruebaIngresoBibliotecario.Repositories.InMemory.Context;

namespace PruebaIngresoBibliotecario.Repositories.InMemory.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersistenceContext _context;

        public UnitOfWork(PersistenceContext context)
        {
            _context = context;
        }

        public void Dispose() => _context.Dispose();

        public void SaveChanges() => _context.SaveChanges();

        public Task SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
