using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.ApiResponse
{
    public class Pagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRegistros { get; set; }
        public Pagination()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
    }
}
