using System;
using System.Collections.Generic;

namespace EntityLib
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Facturasporcobrar = new HashSet<Facturasporcobrar>();
            Listas = new HashSet<Listas>();
        }

        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Apellido { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual Categoriasusuarios IdCategoriaNavigation { get; set; } = null!;
        public virtual ICollection<Facturasporcobrar> Facturasporcobrar { get; set; }
        public virtual ICollection<Listas> Listas { get; set; }
    }
}
