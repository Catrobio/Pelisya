using System;
using System.Collections.Generic;

namespace EntityLib
{
    public partial class Facturasporcobrar
    {
        public int IdFactura { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstado { get; set; }
        public DateTime Fecha { get; set; }
        public string Periodo { get; set; } = null!;
        public decimal Monto { get; set; }
        public decimal? MontoTax { get; set; }
        public decimal? MontoTotal { get; set; }

        public virtual Estadofactura IdEstadoNavigation { get; set; } = null!;
        public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
    }
}
