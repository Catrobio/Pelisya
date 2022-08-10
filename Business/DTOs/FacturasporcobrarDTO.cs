using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class FacturasporcobrarDTO
    {
        public int IdFactura { get; set; }        
        public int IdEstado { get; set; }
        public DateTime Fecha { get; set; }
        public string Periodo { get; set; }
        public decimal Monto { get; set; }
        public decimal? MontoTax { get; set; }
        public decimal? MontoTotal { get; set; }
    }
}
