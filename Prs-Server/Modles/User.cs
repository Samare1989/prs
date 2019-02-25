using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Modles
{
    public class User
{
        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string UserName{ get; set; }
        [StringLength(30)]
        [Required]
        public string Password { get; set; }
        [StringLength(30)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(30)]
        [Required]
        public string LastName { get; set; }
        [StringLength(30)]
        public string Phone { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        public bool IsReviwer { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
        public bool Active { get; set; } = true;
        public User () { }
}

}
