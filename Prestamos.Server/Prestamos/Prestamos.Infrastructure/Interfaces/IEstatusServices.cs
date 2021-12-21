using Prestamos.Core.Entities;
using Prestamos.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Interfaces
{
    public interface IEstatusServices
    {
        Task<IEnumerable<Estatus>> GetAll();
        Task<Estatus> GetById(int id);
    }
}
