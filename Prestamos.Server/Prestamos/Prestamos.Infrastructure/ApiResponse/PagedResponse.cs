using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.ApiResponse
{
    public class PagedResponse<T> : ApiResponse<T>
    {
        public Pagination pagination { get; set; }
        public PagedResponse()
        {
            this.Succeeded = true;
        }
        public PagedResponse(Pagination pagination)
        {
            this.pagination = pagination;
        }
    }
}
