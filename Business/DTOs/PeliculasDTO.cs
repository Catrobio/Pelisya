using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class PeliculasDTO : ErrorDto
    {
        public int IdPelicula { get; set; }
        public int IdCategoriaPeliculas { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string? ActorPrincipal { get; set; }
        public string? ActorPrincipal2 { get; set; }
        public string? ActorSecundario { get; set; }
        public string? ActorSecundario2 { get; set; }
        public string? IdImdb { get; set; }
        public string? Portada { get; set; }
    }
}
