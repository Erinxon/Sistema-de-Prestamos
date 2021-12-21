using Prestamos.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Prestamos.Core.Entities
{
    public partial class EstatusPrestamo
    {
        public EstatusPrestamo()
        {
            DetallePrestamos = new HashSet<DetallePrestamo>();
            Prestamos = new HashSet<Prestamo>();
        }

        public int Id { get; set; }
        public EstatusPrestamosClientes EstatusPrestamos { get; set; }

        [JsonIgnore]
        public ICollection<DetallePrestamo> DetallePrestamos { get; set; }
        [JsonIgnore]
        public ICollection<Prestamo> Prestamos { get; set; }
    }
}
