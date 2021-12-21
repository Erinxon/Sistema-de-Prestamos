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
    public class PeriodoPadoServices : IPeriodoPadoServices
    {
        private readonly PrestamosDBContext _context;

        public PeriodoPadoServices(PrestamosDBContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<PeriodoPago>> GetAll()
        {
            return await this._context.PeriodoPagos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<PeriodoPago> GetById(int id)
        {
            return await this._context.PeriodoPagos
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
