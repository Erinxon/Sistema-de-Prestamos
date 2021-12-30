using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthServices Auth { get; }
        IClienteServices Clientes { get; }
        IDireccionServices Direcciones { get; }
        IEmpresaServices Empresa { get; }
        IEstatusCrediticioServices EstatusCrediticios { get; }
        IEstatusPrestamoServices EstatusPrestamos { get; }
        IPeriodoPadoServices PeriodosPados { get; }
        IPrestamoServices Prestamos { get; }
        IDetallePrestamoServices DetallesPrestamos { get; }
        IRolServices Roles { get; }
        IUsuarioServices Usuarios { get; }
        Task<int> SavechangesAsync();
        void Dispose();
    }
}
