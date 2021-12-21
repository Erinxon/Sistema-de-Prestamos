using Prestamos.Core.Entities;
using Prestamos.Infrastructure.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Interfaces
{
    public interface IAuthServices 
    {
        Task<Usuario> Login(string email, string password);
    }
}
