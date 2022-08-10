using System;
using System.Collections.Generic;

namespace EntityLib
{
    public partial class Peliculas
    {
        public Peliculas()
        {
            Listas = new HashSet<Listas>();
            Subcategorias = new HashSet<Subcategorias>();
        }

        public int IdPelicula { get; set; }
        public int IdCategoriaPeliculas { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateOnly Fecha { get; set; }
        public string? ActorPrincipal { get; set; }
        public string? ActorPrincipal2 { get; set; }
        public string? ActorSecundario { get; set; }
        public string? ActorSecundario2 { get; set; }

        public virtual Categoriacontenido IdCategoriaPeliculasNavigation { get; set; } = null!;
        public virtual ICollection<Listas> Listas { get; set; }
        public virtual ICollection<Subcategorias> Subcategorias { get; set; }
    }
}
