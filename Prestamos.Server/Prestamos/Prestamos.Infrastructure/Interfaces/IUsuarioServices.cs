using Prestamos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Interfaces
{
    public interface IUsuarioServices
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> GetById(int id);
        Task Add(Usuario usuario);
        Task Update(Usuario usuario);
        Task Delete(Usuario usuario);
        Task<bool> IsExistById(int id);
        Task<bool> IsExistCedula(string cedula);
    }
}
