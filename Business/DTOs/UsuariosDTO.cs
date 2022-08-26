using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class UsuariosDTO : ErrorDto
    {
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string? Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaAlta { get; set; }        
        public  List<FacturasporcobrarDTO> ListaFacturas { get; set; }
    }
}
