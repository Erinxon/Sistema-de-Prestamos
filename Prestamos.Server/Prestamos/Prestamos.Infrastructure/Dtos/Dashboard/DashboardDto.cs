using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Dtos.Dashboard
{
    public class DashboardDto
    {
        public int CantidadClientes { get; set; }
        public int CantidadPrestamos { get; set; }
        public int CantidadPrestamosPagados { get; set; }
        public int CantidadPrestamosPendientes { get; set; }
    }
}
