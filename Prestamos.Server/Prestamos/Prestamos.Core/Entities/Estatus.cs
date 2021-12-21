using Prestamos.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Prestamos.Core.Entities
{
    public partial class Estatus
    {
        public Estatus()
        {
            Clientes = new HashSet<Cliente>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public EstatusClientes EstatusClientes { get; set; }

        [JsonIgnore]
        public ICollection<Cliente> Clientes { get; set; }
        [JsonIgnore]
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
