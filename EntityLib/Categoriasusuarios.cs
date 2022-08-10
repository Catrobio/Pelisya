using System;
using System.Collections.Generic;

namespace EntityLib
{
    public partial class Categoriasusuarios
    {
        public Categoriasusuarios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdCategoria { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
