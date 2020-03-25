using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace dbCard.Domain.Models
{
    public abstract class User //: Entity<long>
    {
        public long Id { get; set; }
        [Required]
        public string UserName { get;set; }
        [Required]
        public string Email { get;set; }
        [Required]
        public string Password { get;set; }
        public virtual Customer Customers { get; set; }
        public virtual Partner Partners { get; set; }
    }
}