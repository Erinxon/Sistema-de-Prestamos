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
        public int? IdPeriodoPago { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime FechaCulminacion { get; set; }
        public int? IdEstadusPrestamo { get; set; }
        public int? IdUsuarioUtorizador { get; set; }

        public EstatusPrestamo EstadusPrestamo { get; set; }
        public PeriodoPago PeriodoPago { get; set; }
        public Usuario UsuarioUtorizador { get; set; }
        [JsonIgnore]
        public virtual ICollection<DetallePrestamo> DetallePrestamos { get; set; }
    }
}
