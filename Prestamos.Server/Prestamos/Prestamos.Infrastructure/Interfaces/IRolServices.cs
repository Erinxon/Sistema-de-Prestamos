using Prestamos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Interfaces
{
    public interface IRolServices
    {
        Task<IEnumerable<Role>> GetAll();
        Task<Role> GetById(int id);
    }
}
