namespace PruebaIngresoBibliotecario.Entities.Inteface
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
