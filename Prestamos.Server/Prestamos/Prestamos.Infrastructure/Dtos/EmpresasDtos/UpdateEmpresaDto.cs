using Prestamos.Infrastructure.Dtos.DirecionesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Dtos.EmpresasDtos
{
    public class UpdateEmpresaDto
    {
        public string Nombre { get; set; }
        public string Rnc { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public virtual UpdateDireccionDto Direccion { get; set; }
    }
}
