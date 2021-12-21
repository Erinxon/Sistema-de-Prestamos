using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.ApiResponse
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public ApiResponse()
        {
            this.Succeeded = true;
        }
    }
}
