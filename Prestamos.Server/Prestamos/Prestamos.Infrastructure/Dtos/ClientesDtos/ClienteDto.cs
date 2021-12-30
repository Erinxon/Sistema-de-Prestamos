using Prestamos.Core.Entities;
using Prestamos.Infrastructure.Dtos.DirecionesDtos;
using Prestamos.Infrastructure.Dtos.EnumsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Dtos.ClientesDtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public DateTime? FechaCreado { get; set; }
        public DateTime? FechaActualizado { get; set; }
        public DireccionDto Direccion { get; set; }
        public EstatusCrediticioDto EstatusCrediticio { get; set; }
    }
}
