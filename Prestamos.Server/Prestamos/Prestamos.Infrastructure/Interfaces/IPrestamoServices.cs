using Prestamos.Core.Entities;
using Prestamos.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Interfaces
{
    public interface IPrestamoServices
    {
        Task<IEnumerable<Prestamo>> GetAll(int idUsuario, RolesUsuario rol);
        Task<Prestamo> GetById(int id);
        Task Add(Prestamo prestamo);
    }
}
