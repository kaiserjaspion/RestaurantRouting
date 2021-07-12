using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ts.Restaurant.Order.Context.Models
{
    [Table("Area")]
    public class KitchenAreas : ContextBase
    {
        [Column("IdArea"),Key,DatabaseGenerated(DatabaseGeneratedOption.Identity),Required]
        public long IdArea { get; set; }
        [Column("AreaName"),  Required]
        public string AreaName { get; set; }
        [Column("AreaQueue"), Required]
        public string AreaQueue { get; set; }
    }
}
