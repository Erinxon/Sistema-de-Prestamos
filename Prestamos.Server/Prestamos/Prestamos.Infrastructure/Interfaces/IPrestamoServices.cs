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
        Task<IEnumerable<DetallePrestamo>> GetPrestamosRetrasados();
        Task<bool> VerificarGagoCompleto(int id);
        Task<Prestamo> GetByCedulaCliente(string cedula);
        Task Add(Prestamo prestamo);
        Task<Prestamo> Pagar(Prestamo prestamo);
        Task<bool> IsExistById(int id);
        Task UpdateEstatusPrestamo(int id, EstatusPrestamosClientes estatus);
        Task UpdateEstatusDetallePrestamo(int id, EstatusPrestamosClientes estatus);
        Task<int> GetCount();
    }
}
