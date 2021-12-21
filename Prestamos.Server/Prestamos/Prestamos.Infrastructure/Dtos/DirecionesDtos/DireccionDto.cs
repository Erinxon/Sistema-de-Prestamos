using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Dtos.DirecionesDtos
{
    public class DireccionDto
    {
        public int Id { get; set; }
        public string Provincia { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
    }
}
