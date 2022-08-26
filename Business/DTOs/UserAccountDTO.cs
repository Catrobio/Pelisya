namespace Business.DTOs
{
    public class UserAccountDTO : ErrorDto
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string? Apellido { get; set; }             
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaAlta { get; set; }
        public string? Token { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Validate { get; set; }
        public string? Error { get; set; } 
    }
}
