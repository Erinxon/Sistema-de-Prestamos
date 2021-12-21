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
    public class RolServices : IRolServices
    {
        private readonly PrestamosDBContext _context;

        public RolServices(PrestamosDBContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await this._context.Roles
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Role> GetById(int id)
        {
            return await this._context.Roles
                 .AsNoTracking()
                 .FirstOrDefaultAsync(r => r.Id == id);
        }

    }
}
