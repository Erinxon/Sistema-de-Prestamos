﻿using Microsoft.EntityFrameworkCore;
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
                                             .Include(p => p.DetallePrestamos)
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
                                             .Include(p => p.DetallePrestamos)
                                                .ThenInclude(d => d.EstatusPrestamo)
                                             .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Add(Prestamo prestamo)
        {
            await this._context.Prestamos.AddAsync(prestamo);
        }

        public async Task<int> GetCount()
        {
            return await this._context.Prestamos.CountAsync();
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
                                            .Include(p => p.DetallePrestamos)
                                               .ThenInclude(d => d.EstatusPrestamo)
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
            return await this._context.Prestamos.AnyAsync(p => p.Id == id);
        }
    }
}
