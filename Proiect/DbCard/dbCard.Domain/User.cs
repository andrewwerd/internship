using System;
using System.Collections.Generic;
using System.Text;

namespace dbCard.Domain
{
    public abstract class User : Entity<long>
    {
        public string UserName { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public virtual Customer Customer { get; set; }
        public virtual Partner Partner { get; set; }
    }
}