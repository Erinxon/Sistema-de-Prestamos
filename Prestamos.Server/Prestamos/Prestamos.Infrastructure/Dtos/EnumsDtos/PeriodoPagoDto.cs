﻿using Prestamos.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.Dtos.EnumsDtos
{
    public class PeriodoPagoDto
    {
        public int Id { get; set; }
        public PeriodoDePagos PeriodoDePagos { get; set; }
    }
}
