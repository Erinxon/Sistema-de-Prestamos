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
    public class UpdateUsuarioDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int IdEstatus { get; set; }
        public int IdRol { get; set; }
        public UpdateDireccionDto Direccion { get; set; }
    }
}
