using Prestamos.Infrastructure.Dtos.EnumsDtos;
using Prestamos.Infrastructure.Dtos.UsuariosDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prestamos.Infrastructure.Dtos.PrestamosDtos.DetallePrestamosDto;
using Prestamos.Infrastructure.Dtos.ClientesDtos;

namespace Prestamos.Infrastructure.Dtos.PrestamosDtos
{
    public class PrestamoDto
    {
        public int Id { get; set; }
        public decimal Interes { get; set; }
        public int Cuotas { get; set; }
        public decimal Capital { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime FechaCulminacion { get; set; }
        public EstatusPrestamoDto EstatusPrestamo { get; set; }
        public PeriodoPagoDto PeriodoPago { get; set; }
        public UsuarioDto UsuarioUtorizador { get; set; }
        public ClienteDto Cliente { get; set; }
        public List<DetallePrestamoDto> DetallePrestamos { get; set; }
    }
}
