namespace Web.Models
{
    public class UsuariosModel
    {
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string? Apellido { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaAlta { get; set; }
        public List<FacturasporcobrarModel> ListaFacturas { get; set; }
    }
}
