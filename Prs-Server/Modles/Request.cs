using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Modles
{
    public class Request
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [StringLength(80)]
        public string Description{ get; set; }
        [StringLength(80)]
        public string Justfication{ get; set; }
        [StringLength(80)]
        public string RejectionReason{ get; set; }
        [StringLength(30)]
        public string DeliveryMode{ get; set; }
        public DateTime? SubmittedDate { get; set; }
        [StringLength(10)]
        public string Status { get; set; } = "New";
        [Column(TypeName = "decimal(12,2)")]
        public decimal Total { get; internal set; } = 0;
        public bool Active { get; set; } = true;
        public virtual IList<Requestline> Requestlines { get; set; }

        public Request()
        {

        }
    }
}
