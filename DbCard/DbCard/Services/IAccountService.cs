using DbCard.Domain.Auth;
using DbCard.Infrastructure.Dto.Account;
using DbCard.Infrastructure.Dto.Customer;
using DbCard.Infrastructure.Dto.Partner;
using DbCard.Infrastructure.Dto.User;
using DbCard.Infrastructure.Models;
using System.Threading.Tasks;

namespace DbCard.Services
{
    public interface IAccountService
    {
        Task<LoginResult> Login(UserForLogin userForLogin);
        Task<bool> CustomerRegistration(CustomerForRegistration customerDto);
        Task<bool> PartnerRegistration(PartnerForRegistration customerDto);
        Task<ValidationErrors> ValidateUserName(string userName);
        Task<ValidationErrors> ValidateEmail(string email);
        Task<ValidationErrors> CheckPassword(string password);
        Task<UserForEdit> GetCurrentUserDto();
        Task<bool> EditUser(UserForEdit userForEdit);
        Task<bool> EditPassword(PasswordForEdit passwordForEdit);
    }
}
