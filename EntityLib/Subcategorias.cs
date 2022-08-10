using System;
using System.Collections.Generic;

namespace EntityLib
{
    public partial class Subcategorias
    {
        public int IdSubcategoria { get; set; }
        public int IdCategoria { get; set; }
        public int? IdPelicula { get; set; }
        public int? IdSerie { get; set; }

        public virtual Categoriacontenido IdCategoriaNavigation { get; set; } = null!;
        public virtual Peliculas? IdPeliculaNavigation { get; set; }
        public virtual Series? IdSerieNavigation { get; set; }
    }
}
