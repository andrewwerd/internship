using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApplication.Models
{
    public class User : Entity<long>
    { 
        public string UserName { get;set; }
        
        [EmailAddress]
        public string Email { get;set; }
        public string Password { get;set; }
        public virtual Customer Customer { get; set; }
        public virtual Partner Partner { get; set; }
    }
}