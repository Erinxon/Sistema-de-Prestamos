using System;
using System.Collections.Generic;

#nullable disable

namespace Prestamos.Core.Entities
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public int IdDireccion { get; set; }
        public string Telefono { get; set; }
        public int IdEstatus { get; set; }
        public int IdEstatusCrediticio { get; set; }
        public DateTime? FechaCreado { get; set; }
        public DateTime? FechaActualizado { get; set; }
        public Direccion Direccion { get; set; }
        public Estatus Estatus { get; set; }
        public EstatusCrediticio EstatusCrediticio { get; set; }
    }
}
