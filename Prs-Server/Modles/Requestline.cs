using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Modles
{
    public class Requestline
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
        public virtual Product Product { get; set; }

        public Requestline()
        {

        }
    } 
}
