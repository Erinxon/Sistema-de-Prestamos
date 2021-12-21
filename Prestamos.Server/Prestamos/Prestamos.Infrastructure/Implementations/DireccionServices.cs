using Prestamos.Core.Entities;
using Prestamos.Infrastructure.DbContexts;
using Prestamos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Prestamos.Infrastructure.Implementations
{
    public class DireccionServices : IDireccionServices
    {
        private readonly PrestamosDBContext _context;

        public DireccionServices(PrestamosDBContext context)
        {
            this._context = context;
        }


        public async Task<IEnumerable<Direccion>> GetAll()
        {
            return await this._context.Direccions
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Direccion> GetById(int id)
        {
            return await this._context.Direccions
               .AsNoTracking()
               .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task Add(Direccion direccion)
        {
            await this._context.Direccions.AddAsync(direccion);
        }

        public async Task Update(Direccion direccion)
        {
            this._context.Attach(direccion).State = EntityState.Modified;
        }

        public async Task Delete(Direccion direccion)
        {
            this._context.Attach(direccion).State = EntityState.Deleted;
        }
    }
}
