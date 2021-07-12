using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ts.Restaurant.Order.Context.Models
{
    public class ContextBase
    {
        [Column("IsActive")]
        public bool IsActive { get; set; } = true;
        [Column("DtCreated")]
        public DateTime DtCreated { get; set; } = DateTime.Now;
        [Column("CreatedBy"), Required]
        public string CreatedBy { get; set; } = "Bruno Pires";
    }
}
