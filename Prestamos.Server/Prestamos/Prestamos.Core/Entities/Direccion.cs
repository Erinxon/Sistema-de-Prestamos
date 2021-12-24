using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Prestamos.Core.Entities
{
    public partial class Direccion
    {
        public Direccion()
        {
            Clientes = new HashSet<Cliente>();
            Empresas = new HashSet<Empresa>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Provincia { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Empresa> Empresas { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
