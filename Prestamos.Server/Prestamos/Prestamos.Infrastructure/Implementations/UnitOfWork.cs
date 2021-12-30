using Prestamos.Infrastructure.DbContexts;
using Prestamos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PrestamosDBContext _context;
        public IAuthServices Auth { get; private set; }
        public IClienteServices Clientes { get; private set; }
        public IDireccionServices Direcciones { get; private set; }
        public IEmpresaServices Empresa { get; private set; }
        public IEstatusCrediticioServices EstatusCrediticios { get; private set; }
        public IEstatusPrestamoServices EstatusPrestamos { get; private set; }
        public IPeriodoPadoServices PeriodosPados { get; private set; }
        public IPrestamoServices Prestamos { get; private set; }
        public IDetallePrestamoServices DetallesPrestamos { get; private set; }
        public IRolServices Roles { get; private set; }
        public IUsuarioServices Usuarios { get; private set; }

        public UnitOfWork(PrestamosDBContext context)
        {
            this._context = context;
            this.Auth = new AuthServices(_context);
            this.Clientes = new ClienteServices(_context);
            this.Direcciones = new DireccionServices(_context);
            this.Empresa = new EmpresaServices(_context);
            this.EstatusCrediticios = new EstatusCrediticioServices(_context);
            this.EstatusPrestamos = new EstatusPrestamoServices(_context);
            this.PeriodosPados = new PeriodoPadoServices(_context);
            this.Prestamos = new PrestamoServices(_context);
            this.DetallesPrestamos = new DetallePrestamoServices(context);
            this.Roles = new RolServices(_context);
            this.Usuarios = new UsuarioServices(_context);
        }

        public async Task<int> SavechangesAsync()
        {
            return await this._context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
