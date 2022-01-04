using Prestamos.Infrastructure.Dtos.EnumsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Dtos.PrestamosDtos.DetallePrestamosDto
{
    public class DetallePrestamoDto
    {
        public int Id { get; set; }
        public int NumeroCuota { get; set; }
        public decimal CuotaPagar { get; set; }
        public decimal InteresPagar { get; set; }
        public decimal CapitalAmortizado { get; set; }
        public decimal? Pagado { get; set; }
        public decimal CapitalPendiente { get; set; }
        public DateTimeOffset FechaPago { get; set; }
        public int IdEstatusPrestamo { get; set; }
        public int IdPrestamo { get; set; }
        public EstatusPrestamoDto EstatusPrestamo { get; set; }
    }
}
