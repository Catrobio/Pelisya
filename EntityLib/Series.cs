using System;
using System.Collections.Generic;

namespace EntityLib
{
    public partial class Series
    {
        public Series()
        {
            Listas = new HashSet<Listas>();
            Subcategorias = new HashSet<Subcategorias>();
        }

        public int IdSerie { get; set; }
        public int IdCategoriaSeries { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string? ActorPrincipal { get; set; }
        public string? ActorPrincipal2 { get; set; }
        public string? ActorSecundario { get; set; }
        public string? ActorSecundario2 { get; set; }
        public string? IdImdb { get; set; }
        public string? Portada { get; set; }

        public virtual Categoriacontenido IdCategoriaSeriesNavigation { get; set; } = null!;
        public virtual ICollection<Listas> Listas { get; set; }
        public virtual ICollection<Subcategorias> Subcategorias { get; set; }
    }
}
