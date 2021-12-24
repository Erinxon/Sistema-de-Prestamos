using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Dtos.PrestamosDtos.DetallePrestamosDto
{
    public class AddDetallePrestamoDto
    {
        public int NumeroCuota { get; set; }
        public decimal CuotaPagar { get; set; }
        public decimal InteresPagar { get; set; }
        public decimal CapitalAmortizado { get; set; }
        public decimal? Pagado { get; set; }
        public decimal CapitalPendiente { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
