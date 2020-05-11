using Microsoft.AspNetCore.Http;

namespace DbCard.Infrastructure.Dto.Customer
{
    public class Customer
    {
        public IFormFile Avatar { get; set; }
        public long Id { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
    }
}
