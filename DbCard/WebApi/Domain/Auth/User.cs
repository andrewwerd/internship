using Microsoft.AspNetCore.Identity;

namespace Domain.Auth
{
    public class User: IdentityUser<long>
    {
        public virtual Customer Customer { get; set; }
        public virtual Partner Partner { get; set; }
    }
}
