namespace PruebaIngresoBibliotecario.UseCasesDTOs.CreateLoan
{
    public class CreateLoanParameters
    {
        public string? Isbn { get; set; } 
        public string? IdentificacionUsuario { get; set; }
        public int TipoUsuario { get; set; }
    }
}
