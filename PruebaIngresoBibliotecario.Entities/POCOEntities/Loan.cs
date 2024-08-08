using PruebaIngresoBibliotecario.Entities.Enums;

namespace PruebaIngresoBibliotecario.Entities.POCOEntities
{
    public class Loan
    {
        public Guid Id { get; set; } //Primary
        public Guid Isbn { get; set; } // Numero Libro
        public string IdentificacionUsuario { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public DateTime FechaDevolucionPrestamoLibro { get; set; }
    }
}
