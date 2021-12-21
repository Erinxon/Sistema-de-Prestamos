using Prestamos.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Prestamos.Core.Entities
{
    public partial class PeriodoPago
    {
        public PeriodoPago()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int Id { get; set; }
        public PeriodoDePagos PeriodoDePagos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
