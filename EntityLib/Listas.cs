using System;
using System.Collections.Generic;

namespace EntityLib
{
    public partial class Listas
    {
        public int IdLista { get; set; }
        public int IdUsuario { get; set; }
        public int? IdPelicula { get; set; }
        public int? IdSerie { get; set; }

        public virtual Peliculas? IdPeliculaNavigation { get; set; }
        public virtual Series? IdSerieNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
    }
}
