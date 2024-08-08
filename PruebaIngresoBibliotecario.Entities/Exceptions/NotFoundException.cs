namespace PruebaIngresoBibliotecario.Entities.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() { }
        public NotFoundException(string mensaje) : base(mensaje) { }
    }
}
