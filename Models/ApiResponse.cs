using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
            Status = System.Net.HttpStatusCode.OK;
        }

        public System.Net.HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

    }
}
