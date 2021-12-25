using Prestamos.Core.Entities;
using Prestamos.Infrastructure.DbContexts;
using Prestamos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Prestamos.Infrastructure.ApiResponse;
using Prestamos.Core.Entities.Enums;

namespace Prestamos.Infrastructure.Implementations
{
    public class ClienteServices : IClienteServices
    {
        private readonly PrestamosDBContext _context;

        public ClienteServices(PrestamosDBContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAll(Pagination pagination)
        {
            return await this._context.Clientes
                .AsNoTracking()
                .Include(c => c.Direccion)
                .Include(c => c.Estatus)
                .Include(c => c.EstatusCrediticio)
                .OrderByDescending(c => c.Id)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();
        }

        public async Task<Cliente> GetById(int id)
        {
            var cliente = await this._context.Clientes
                .AsNoTracking()
                .Include(c => c.Direccion)
                .Include(c => c.Estatus)
                .Include(c => c.EstatusCrediticio)
                .FirstOrDefaultAsync(c => c.Id == id);
            return cliente;
        }

        public async Task Add(Cliente cliente)
        {
            await this._context.Clientes.AddAsync(cliente);
        }

        public async Task Update(Cliente cliente)
        {
            this._context.Clientes.Attach(cliente).State = EntityState.Modified;
        }
        public async Task Delete(Cliente cliente)
        {
            this._context.Clientes.Attach(cliente).State = EntityState.Deleted;
        }

        public async Task<bool> IsExistById(int id)
        {
            return await this._context.Clientes
                .AsNoTracking()
                .AnyAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cliente>> Filter(string filter, Pagination pagination)
        {
            return await this._context.Clientes
                .AsNoTracking()
                .Include(c => c.Direccion)
                .Include(c => c.Estatus)
                .Include(c => c.EstatusCrediticio)
                .Where(c => c.Nombres.Contains(filter) || c.Apellidos.Contains(filter))
                .OrderByDescending(c => c.Id)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await this._context.Clientes.CountAsync();
        }

        public async Task<Cliente> GetByCedula(string cedula)
        {
            var cliente = await this._context.Clientes
               .AsNoTracking()
               .Include(c => c.Direccion)
               .Include(c => c.Estatus)
               .Include(c => c.EstatusCrediticio)
               .FirstOrDefaultAsync(c => c.Cedula == cedula);
            return cliente;
        }

        public async Task CambiarEstatusCrediticio(int id, int idEstatusCrediticio)
        {
            var cliente = await this._context.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            cliente.IdEstatusCrediticio = idEstatusCrediticio;
            await this.Update(cliente);
        }

        public async Task<bool> ClienteHasPrestamos(int id)
        {
            return await this._context.Prestamos
                .AsNoTracking()
                .AnyAsync(p => p.IdCliente == id);
        }
    }
}
