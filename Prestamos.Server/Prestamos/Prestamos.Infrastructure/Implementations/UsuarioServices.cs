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
    public class UsuarioServices : IUsuarioServices
    {
        private readonly PrestamosDBContext _context;

        public UsuarioServices(PrestamosDBContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await this._context.Usuarios
                .AsNoTracking()
                .Include(c => c.Direccion)
                .Include(c => c.Estatus)
                .Include(c => c.Rol)
                .ToListAsync();
        }

        public async Task<Usuario> GetById(int id)
        {
            return await this._context.Usuarios
                .AsNoTracking()
                .Include(c => c.Direccion)
                .Include(c => c.Estatus)
                .Include(c => c.Rol)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task Add(Usuario usuario)
        {
            await this._context.Usuarios.AddAsync(usuario);
        }

        public async Task Update(Usuario usuario)
        {
            this._context.Attach(usuario).State = EntityState.Modified;
        }

        public async Task Delete(Usuario usuario)
        {
            this._context.Attach(usuario).State = EntityState.Deleted;
        }

        public async Task<bool> IsExistById(int id)
        {
            return await this._context.Usuarios
               .AsNoTracking()
               .AnyAsync(c => c.Id == id);
        }

        public async Task<bool> IsExistCedula(string cedula)
        {
            return await this._context.Usuarios
                .AsNoTracking()
                .AnyAsync(c => c.Cedula == cedula);
        }

    }
}
