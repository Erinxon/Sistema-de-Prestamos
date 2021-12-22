using Prestamos.Core.Entities;
using Prestamos.Infrastructure.Dtos.DirecionesDtos;
using Prestamos.Infrastructure.Dtos.EnumsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Dtos.UsuariosDtos
{
    public class AddUsuarioDto
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Password { get; set; }
        public AddDireccionDto Direccion { get; set; }
        public int IdRol { get; set; }
    }
}
