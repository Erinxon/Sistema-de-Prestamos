using Prestamos.Core.Entities;
using Prestamos.Core.Entities.Enums;
using Prestamos.Infrastructure.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Interfaces
{
    public interface IPrestamoServices
    {
        Task<IEnumerable<Prestamo>> GetAll(Pagination pagination);
        Task<Prestamo> GetById(int id);
        Task<Prestamo> GetByCedulaCliente(string cedula);
        Task Add(Prestamo prestamo);
        Task<Prestamo> Pagar(Prestamo prestamo);
        Task<bool> IsExistById(int id);
        Task<int> GetCount();
    }
}
