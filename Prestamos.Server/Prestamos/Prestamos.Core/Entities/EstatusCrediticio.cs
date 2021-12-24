using Prestamos.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Prestamos.Core.Entities
{
    public partial class EstatusCrediticio
    {
        public EstatusCrediticio()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int Id { get; set; }
        public EstatuCrediticioCliente EstatusCrediticios { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
