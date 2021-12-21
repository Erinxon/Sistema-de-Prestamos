using Prestamos.Core.Entities;
using Prestamos.Infrastructure.DbContexts;
using Prestamos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prestamos.Core.Entities.Enums;

namespace Prestamos.Infrastructure.Implementations
{
    public class EstatusServices : IEstatusServices
    {
        private readonly PrestamosDBContext _context;

        public EstatusServices(PrestamosDBContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Estatus>> GetAll()
        {
            return await this._context.Estatuses
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Estatus> GetById(int id)
        {
            return await this._context.Estatuses
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

    }
}
