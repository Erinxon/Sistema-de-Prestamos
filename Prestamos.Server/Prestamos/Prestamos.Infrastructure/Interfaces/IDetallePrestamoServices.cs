using Prestamos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Interfaces
{
    public interface IDetallePrestamoServices
    {
        Task Add(List<DetallePrestamo> detallePrestamo);
    }
}
