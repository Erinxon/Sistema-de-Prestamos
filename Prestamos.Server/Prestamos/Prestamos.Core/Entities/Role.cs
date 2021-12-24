using Prestamos.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Prestamos.Core.Entities
{
    public partial class Role
    {
        public Role()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public RolesUsuario Roles { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
