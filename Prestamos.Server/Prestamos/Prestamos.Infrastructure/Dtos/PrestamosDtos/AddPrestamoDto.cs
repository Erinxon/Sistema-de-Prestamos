using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prestamos.Infrastructure.Dtos.PrestamosDtos.DetallePrestamosDto;

namespace Prestamos.Infrastructure.Dtos.PrestamosDtos
{
    public class AddPrestamoDto
    {
        public decimal Interes { get; set; }
        public int Cuotas { get; set; }
        public decimal Capital { get; set; }
        public int IdPeriodoPago { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime FechaCulminacion { get; set; }
        public int IdUsuarioUtorizador { get; set; }
        public int IdCliente { get; set; }
        public List<AddDetallePrestamoDto> DetallePrestamo { get; set; }
    }
}
