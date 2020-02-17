using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Authorization
    {
        public Guid SessionId { get; set; }
        public string FirstName { get; set; }
        public string AccessToken { get; set; }
    }
}
