using Prestamos.Core.Entities;
using Prestamos.Infrastructure.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Interfaces
{
    public interface IClienteServices
    {
        Task<IEnumerable<Cliente>> GetAll(Pagination pagination);
        Task<IEnumerable<Cliente>> Filter(string filter, Pagination pagination);
        Task<Cliente> GetById(int id);
        Task<Cliente> GetByCedula(string cedula);
        Task Add(Cliente cliente);
        Task Update(Cliente cliente);
        Task Delete(Cliente cliente);
        Task<bool> IsExistById(int id);
        Task<int> GetCount();
    }
}
