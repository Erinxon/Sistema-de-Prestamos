using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Prestamos.Core.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Empresas = new HashSet<Empresa>();
            Prestamos = new HashSet<Prestamo>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public int IdDireccion { get; set; }
        public string Telefono { get; set; }
        public int IdRol { get; set; }
        public string Password { get; set; }
        public DateTime? FechaCreado { get; set; }
        public DateTime? FechaActualizado { get; set; }
        public Direccion Direccion { get; set; }
        public Role Rol { get; set; }
        public ICollection<Empresa> Empresas { get; set; }
        public ICollection<Prestamo> Prestamos { get; set; }
    }
}
