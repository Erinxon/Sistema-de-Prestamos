using Microsoft.EntityFrameworkCore;
using Prestamos.Core.Entities;
using Prestamos.Infrastructure.DbContexts;
using Prestamos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Implementations
{
    public class EstatusPrestamoServices : IEstatusPrestamoServices
    {
        private readonly PrestamosDBContext _context;

        public EstatusPrestamoServices(PrestamosDBContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<EstatusPrestamo>> GetAll()
        {
            return await this._context.EstatusPrestamos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<EstatusPrestamo> GetById(int id)
        {
            return await this._context.EstatusPrestamos
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
