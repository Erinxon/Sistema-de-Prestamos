using Prestamos.Core.Entities;
using Prestamos.Infrastructure.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Interfaces
{
    public interface IUsuarioServices
    {
        Task<IEnumerable<Usuario>> GetAll(Pagination pagination);
        Task<IEnumerable<Usuario>> Filter(string filter, Pagination pagination);
        Task<Usuario> GetById(int id);
        Task Add(Usuario usuario);
        Task Update(Usuario usuario);
        Task Delete(Usuario usuario);
        Task<bool> IsExistById(int id);
        Task<bool> IsExistCedula(string cedula);
        Task<int> GetCount();
    }
}
