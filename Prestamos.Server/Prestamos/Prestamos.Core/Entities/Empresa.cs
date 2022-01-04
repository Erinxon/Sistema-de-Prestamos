using System;
using System.Collections.Generic;

#nullable disable

namespace Prestamos.Core.Entities
{
    public partial class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rnc { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTimeOffset? FechaCreado { get; set; }
        public DateTimeOffset? FechaActualizado { get; set; }
        public int? IdDireccion { get; set; }
        public int? IdAdministrador { get; set; }

        public virtual Usuario  Administrador { get; set; }
        public virtual Direccion Direccion { get; set; }
    }
}
