using System;
using System.Collections.Generic;

namespace EntityLib
{
    public partial class Estadofactura
    {
        public Estadofactura()
        {
            Facturasporcobrar = new HashSet<Facturasporcobrar>();
        }

        public int IdEstado { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Facturasporcobrar> Facturasporcobrar { get; set; }
    }
}
