using Prestamos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Interfaces
{
    public interface IEmpresaServices
    {
        Task<Empresa> Get();
        Task<Empresa> Get(int id);
        Task Update(Empresa empresa);
        Task<bool> IsExistById(int id);
    } 
}
