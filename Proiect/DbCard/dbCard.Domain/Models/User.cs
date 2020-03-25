using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace dbCard.Domain.Models
{
    public class User : Entity<long>
    { 
        [Required]
        public string UserName { get;set; }
        [Required]
        public string Email { get;set; }
        [Required]
        public string Password { get;set; }
        public virtual Customer Customer { get; set; }
        public virtual Partner Partner { get; set; }
    }
}