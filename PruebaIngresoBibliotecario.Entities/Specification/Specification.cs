using System.Linq.Expressions;

namespace PruebaIngresoBibliotecario.Entities.Specification
{
    public abstract class Specification<TEntity>
    {
        public abstract Expression<Func<TEntity, bool>> Expression { get; set; } 
    }
}
