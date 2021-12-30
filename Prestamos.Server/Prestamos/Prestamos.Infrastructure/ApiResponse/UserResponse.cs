using Prestamos.Core.Entities;
using Prestamos.Infrastructure.Dtos.EnumsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.ApiResponse
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public RolDto Rol { get; set; }
        public string Token { get; set; }

        public UserResponse(Usuario usuario)
        {
            this.Id = usuario.Id;   
            this.Nombres = usuario.Nombres;
            this.Apellidos = usuario.Apellidos;
            this.Email = usuario.Email;
        }
    }
}
