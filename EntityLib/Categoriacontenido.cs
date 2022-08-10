using System;
using System.Collections.Generic;

namespace EntityLib
{
    public partial class Categoriacontenido
    {
        public Categoriacontenido()
        {
            Peliculas = new HashSet<Peliculas>();
            Series = new HashSet<Series>();
            Subcategorias = new HashSet<Subcategorias>();
        }

        public int IdCategoria { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Peliculas> Peliculas { get; set; }
        public virtual ICollection<Series> Series { get; set; }
        public virtual ICollection<Subcategorias> Subcategorias { get; set; }
    }
}
