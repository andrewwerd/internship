using DbCard.Infrastructure.Dto.Customer;
using DbCard.Infrastructure.Dto.Partner;
using DbCard.Infrastructure.Dto.User;
using DbCard.Services.Implementatios;
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
