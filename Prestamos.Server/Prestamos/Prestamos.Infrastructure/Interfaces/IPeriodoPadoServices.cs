using Prestamos.Core.Entities;
using Prestamos.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Interfaces
{
    public interface IPeriodoPadoServices
    {
        Task<IEnumerable<PeriodoPago>> GetAll();
        Task<PeriodoPago> GetById(int id);
    }
}
