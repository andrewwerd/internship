using Domain.Auth;
using WebApi.Infrastructure.DTO.Account;
using WebApi.Infrastructure.DTO.Customer;
using WebApi.Infrastructure.DTO.Partner;
using WebApi.Infrastructure.Models;

namespace WebApi.Services
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
        Task<LoginResult> GenerateJwtTokenAsync(User user);
    }
}
