using Microsoft.AspNetCore.Identity;

namespace DbCard.Domain.Auth
{
    public class User: IdentityUser<long>
    {
        public virtual Customer Customer { get; set; }
        public virtual Partner Partner { get; set; }
    }
}
