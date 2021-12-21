using Prestamos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Interfaces
{
    public interface IDireccionServices
    {
        Task<IEnumerable<Direccion>> GetAll();
        Task<Direccion> GetById(int id);
        Task Add(Direccion direccion);
        Task Update(Direccion direccion);
        Task Delete(Direccion direccion);
    }
}
