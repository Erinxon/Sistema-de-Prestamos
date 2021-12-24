using System;
using System.Collections.Generic;

#nullable disable

namespace Prestamos.Core.Entities
{
    public partial class DetallePrestamo
    {
        public int Id { get; set; }
        public int NumeroCuota { get; set; }
        public decimal CuotaPagar { get; set; }
        public decimal InteresPagar { get; set; }
        public decimal CapitalAmortizado { get; set; }
        public decimal? Pagado { get; set; }
        public decimal CapitalPendiente { get; set; }
        public DateTime FechaPago { get; set; }
        public int IdEstatusPrestamo { get; set; }
        public int IdPrestamo { get; set; }
        public EstatusPrestamo EstatusPrestamo { get; set; }
        public Prestamo Prestamo { get; set; }
    }
}
