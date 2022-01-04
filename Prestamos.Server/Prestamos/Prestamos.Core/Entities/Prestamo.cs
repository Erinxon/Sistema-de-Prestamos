using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Prestamos.Core.Entities
{
    public partial class Prestamo
    {
        public Prestamo()
        {
            DetallePrestamos = new HashSet<DetallePrestamo>();
        }

        public int Id { get; set; }
        public decimal Interes { get; set; }
        public int Cuotas { get; set; }
        public decimal Capital { get; set; }
        public int IdPeriodoPago { get; set; }
        public DateTimeOffset FechaCreado { get; set; }
        public DateTimeOffset FechaCulminacion { get; set; }
        public int IdEstatusPrestamo { get; set; }
        public int IdUsuarioUtorizador { get; set; }
        public int IdCliente { get; set; }
        public EstatusPrestamo EstatusPrestamo { get; set; }
        public PeriodoPago PeriodoPago { get; set; }
        public Usuario UsuarioUtorizador { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<DetallePrestamo> DetallePrestamos { get; set; }
    }
}
