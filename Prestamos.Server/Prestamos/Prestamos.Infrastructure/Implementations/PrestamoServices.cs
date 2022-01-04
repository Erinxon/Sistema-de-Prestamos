using Microsoft.EntityFrameworkCore;
using Prestamos.Core.Entities;
using Prestamos.Core.Entities.Enums;
using Prestamos.Infrastructure.ApiResponse;
using Prestamos.Infrastructure.DbContexts;
using Prestamos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Implementations
{
    public class PrestamoServices : IPrestamoServices
    {
        private readonly PrestamosDBContext _context;

        public PrestamoServices(PrestamosDBContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Prestamo>> GetAll(Pagination pagination)
        {
            var prestamos = await this._context.Prestamos
                                             .AsNoTracking()
                                             .Include(p => p.Cliente)
                                                 .ThenInclude(c => c.Direccion)
                                             .Include(p => p.Cliente)
                                                 .ThenInclude(c => c.EstatusCrediticio)
                                             .Include(p => p.EstatusPrestamo)
                                             .Include(p => p.PeriodoPago)
                                             .Include(p => p.UsuarioUtorizador)
                                             .Include(p => p.DetallePrestamos.OrderBy(d => d.NumeroCuota))
                                             .OrderByDescending(p => p.Id)
                                             .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                                             .Take(pagination.PageSize)
                                             .ToListAsync();
            return prestamos;
        }

        public async Task<Prestamo> GetById(int id)
        {
            return await this._context.Prestamos
                                             .AsNoTracking()
                                            .Include(p => p.Cliente)
                                                 .ThenInclude(c => c.Direccion)
                                             .Include(p => p.Cliente)
                                                 .ThenInclude(c => c.EstatusCrediticio)
                                             .Include(p => p.EstatusPrestamo)
                                             .Include(p => p.PeriodoPago)
                                             .Include(p => p.UsuarioUtorizador)
                                                .ThenInclude(u => u.Rol)
                                             .Include(p => p.DetallePrestamos.OrderBy(d => d.NumeroCuota))
                                                .ThenInclude(d => d.EstatusPrestamo)
                                             .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Add(Prestamo prestamo)
        {
            await this._context.Prestamos.AddAsync(prestamo);
        }

        public async Task<int> GetCount()
        {
            return await this._context.Prestamos
                .AsNoTracking()
                .CountAsync();
        }

        public async Task<Prestamo> GetByCedulaCliente(string cedula)
        {
            return await this._context.Prestamos
                                           .AsNoTracking()
                                           .Include(p => p.Cliente)
                                                .ThenInclude(c => c.Direccion)
                                            .Include(p => p.Cliente)
                                                .ThenInclude(c => c.EstatusCrediticio)
                                            .Include(p => p.EstatusPrestamo)
                                            .Include(p => p.PeriodoPago)
                                            .Include(p => p.UsuarioUtorizador)
                                               .ThenInclude(u => u.Rol)
                                            .Include(p => p.DetallePrestamos.OrderBy(d => d.NumeroCuota))
                                               .ThenInclude(d => d.EstatusPrestamo)
                                            .OrderByDescending(d => d.Id)
                                            .FirstOrDefaultAsync(p => p.Cliente.Cedula == cedula 
                                                && p.Cliente.EstatusCrediticio.EstatusCrediticios 
                                                != EstatuCrediticioCliente.Libre
                                                && p.EstatusPrestamo.EstatusPrestamos 
                                                != EstatusPrestamosClientes.Pagado);
        }

        public async Task<Prestamo> Pagar(Prestamo prestamo)
        {
            this._context.Attach(prestamo).State = EntityState.Modified;
            return await this.GetByCedulaCliente(prestamo.Cliente.Cedula);
        }

        public async Task<bool> IsExistById(int id)
        {
            return await this._context.Prestamos
                .AsNoTracking()
                .AnyAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<DetallePrestamo>> GetPrestamosRetrasados()
        {
            var prestamos = await this._context.DetallePrestamos
                .AsNoTracking()
                .Include(d => d.Prestamo)
                .ThenInclude(p => p.EstatusPrestamo)
                .Include(d => d.Prestamo)
                .ThenInclude(p => p.Cliente)
                .Include(d => d.Prestamo)
                .ThenInclude(p => p.PeriodoPago)
                .Include(d => d.Prestamo)
                .ThenInclude(p => p.UsuarioUtorizador)
                .Where(p => (p.EstatusPrestamo.EstatusPrestamos == EstatusPrestamosClientes.Pendiente ||
                p.EstatusPrestamo.EstatusPrestamos == EstatusPrestamosClientes.Abono) &&
                           p.FechaPago < DateTimeOffset.Now)
                .OrderBy(d => d.NumeroCuota)
                .ToListAsync();
            return prestamos;
        }

        public async Task<bool> VerificarGagoCompleto(int id)
        {
            var prestamo = await this.GetById(id);
            return prestamo.DetallePrestamos.
                All(d => d.CuotaPagar == d.Pagado);
        }

        public async Task UpdateEstatusPrestamo(int id, EstatusPrestamosClientes estatus)
        {
            var prestamo = await this._context.Prestamos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            prestamo.IdEstatusPrestamo = (int)estatus;
            this._context.Attach(prestamo).State = EntityState.Modified;
        }

        public async Task UpdateEstatusDetallePrestamo(int id, EstatusPrestamosClientes estatus)
        {
            var detalle = await this._context.DetallePrestamos.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
            detalle.IdEstatusPrestamo = (int) estatus;
            this._context.Attach(detalle).State = EntityState.Modified;
        }

        public async Task<int> GetCountPrestamosPagado()
        {
            return await this._context.Prestamos.AsNoTracking()
                 .Include(p => p.EstatusPrestamo)
                 .Where(p => p.EstatusPrestamo.EstatusPrestamos == EstatusPrestamosClientes.Pagado)
                 .CountAsync();
        }

        public async Task<int> GetCountPrestamosAtrasado()
        {
            return await this._context.Prestamos.AsNoTracking()
                .Include(p => p.EstatusPrestamo)
                .Where(p => p.EstatusPrestamo.EstatusPrestamos != EstatusPrestamosClientes.Pagado)
                .CountAsync();
        }
    }
}
