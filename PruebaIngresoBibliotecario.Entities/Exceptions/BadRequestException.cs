namespace PruebaIngresoBibliotecario.Entities.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() { }
        public BadRequestException(string mensaje) : base(mensaje) { }
    }
}
