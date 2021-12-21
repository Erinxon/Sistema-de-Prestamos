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
    public class AuthServices : IAuthServices
    {
        private readonly PrestamosDBContext _context;

        public AuthServices(PrestamosDBContext context)
        {
            this._context = context;
        }

        public async Task<Usuario> Login(string email, string password)
        {
            return await this._context.Usuarios
                .AsNoTracking()
                .Include(c => c.Estatus)
                .Include(c => c.Rol)
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
