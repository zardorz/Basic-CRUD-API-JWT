using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Session
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public DateTime DtCreated { get; set; }

        [Required]
        public DateTime DtExpire { get; set; }
    }
}
