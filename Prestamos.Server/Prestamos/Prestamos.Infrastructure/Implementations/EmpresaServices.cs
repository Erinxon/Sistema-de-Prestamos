using Prestamos.Core.Entities;
using Prestamos.Infrastructure.DbContexts;
using Prestamos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Prestamos.Infrastructure.Implementations
{
    public class EmpresaServices : IEmpresaServices
    {
        private readonly PrestamosDBContext _context;

        public EmpresaServices(PrestamosDBContext context)
        {
            this._context = context;
        }

        public async Task<Empresa> Get()
        {
            return await this._context.Empresas
                .AsNoTracking()
                .Include(e => e.Administrador)
                .Include(e => e.Direccion)
                .FirstOrDefaultAsync();
        }

        public async Task<Empresa> Get(int id)
        {
            return await this._context.Empresas
                .AsNoTracking()
                .Include(e => e.Administrador)
                .Include(e => e.Direccion)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Update(Empresa empresa)
        {
            _context.Attach(empresa).State = EntityState.Modified;
        }


        public async Task<bool> IsExistById(int id)
        {
            return await this._context.Empresas
                .AsNoTracking()
                .AnyAsync(e => e.Id == id);
        }
    }
}
