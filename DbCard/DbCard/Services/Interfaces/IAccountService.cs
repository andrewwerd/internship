using DbCard.Infrastructure.DTO.Customer;
using DbCard.Infrastructure.DTO.Partner;
using DbCard.Infrastructure.DTO.User;
using System.Threading.Tasks;

namespace DbCard.Services
{
    public interface IAccountService
    {
        Task<LoginResult> Login(UserForLogin userForLogin);
        Task<bool> CustomerRegistration(CustomerForRegistration customerDto);
        Task<bool> PartnerRegistration(PartnerForRegistration customerDto);
    }
}
