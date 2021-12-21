using Prestamos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Interfaces
{
    public interface IEstatusPrestamoServices
    {
        Task<IEnumerable<EstatusPrestamo>> GetAll();
        Task<EstatusPrestamo> GetById(int id);
    }
}
