﻿using Prestamos.Core.Entities;
using Prestamos.Infrastructure.DbContexts;
using Prestamos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Implementations
{
    public class DetallePrestamoServices : IDetallePrestamoServices
    {
        private readonly PrestamosDBContext _context;

        public DetallePrestamoServices(PrestamosDBContext context)
        {
            this._context = context;
        }
        public async Task Add(List<DetallePrestamo> detallePrestamo)
        {
            await this._context.AddRangeAsync(detallePrestamo);
        }
    }
}
