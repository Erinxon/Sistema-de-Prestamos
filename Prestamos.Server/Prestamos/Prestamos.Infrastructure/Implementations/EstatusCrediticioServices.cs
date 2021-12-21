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
    public class EstatusCrediticioServices : IEstatusCrediticioServices
    {
        private readonly PrestamosDBContext _context;

        public EstatusCrediticioServices(PrestamosDBContext context)
        {
            this._context = context;
        }


        public async Task<IEnumerable<EstatusCrediticio>> GetAll()
        {
           return await this._context.EstatusCrediticios
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<EstatusCrediticio> GetById(int id)
        {
            return await this._context.EstatusCrediticios
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

    }
}
