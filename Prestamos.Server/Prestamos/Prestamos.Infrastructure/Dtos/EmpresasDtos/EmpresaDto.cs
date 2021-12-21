using Prestamos.Core.Entities;
using Prestamos.Infrastructure.Dtos.DirecionesDtos;
using Prestamos.Infrastructure.Dtos.UsuariosDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Dtos.EmpresasDtos
{
    public class EmpresaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rnc { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime? FechaCreado { get; set; }
        public DateTime? FechaActualizado { get; set; }
        public UsuarioDto Administrador { get; set; }
        public DireccionDto Direccion { get; set; }
    }
}
