using Prestamos.Core.Entities;
using Prestamos.Infrastructure.Dtos.DirecionesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Dtos.ClientesDtos
{
    public class AddClienteDto
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public AddDireccionDto Direccion { get; set; }
    }
}
