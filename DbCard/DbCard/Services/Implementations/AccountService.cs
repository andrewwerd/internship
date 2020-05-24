using DbCard.Domain.Auth;
using DbCard.Infrastructure.Configuration;
using DbCard.Infrastructure.Dto.Customer;
using DbCard.Infrastructure.Dto.Partner;
using DbCard.Infrastructure.Dto.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using DbCard.Infrastructure.Models;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DbCard.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly AuthOptions _authenticationOptions;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly ICustomerService _customerService;
        private readonly IPartnerService _partnerService;
        public AccountService(IOptions<AuthOptions> authenticationOptions, SignInManager<User> signInManager, UserManager<User> userManager, ICustomerService customerService, IPartnerService partnerService)
        {
            _authenticationOptions = authenticationOptions.Value;
            _signInManager = signInManager;
            _userManager = userManager;
            _customerService = customerService;
            _partnerService = partnerService;
        }

        public async Task<bool> CustomerRegistration(CustomerForRegistration customerDto)
        {
            var user = new User { Email = customerDto.Email, UserName = customerDto.UserName, PhoneNumber = customerDto.PhoneNumber };
            var userCreating = await _userManager.CreateAsync(user, customerDto.Password);
            if (userCreating.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
                var customerCreating = await _customerService.CreateFromDtoAsync(customerDto, user);
                return customerCreating;
            }
            else
                return userCreating.Succeeded;
        }

        public async Task<bool> PartnerRegistration(PartnerForRegistration partnerDto)
        {
            var user = new User { Email = partnerDto.Email, UserName = partnerDto.UserName, PhoneNumber = partnerDto.PhoneNumber};
            var userCreating = await _userManager.CreateAsync(user, partnerDto.Password);
            if (userCreating.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Partner");
                var partnerCreating = await _partnerService.CreateFromDtoAsync(partnerDto, user);
                if (!partnerCreating) await _userManager.DeleteAsync(user);
                return partnerCreating;
            }
            else
                return userCreating.Succeeded;
        }
        public async Task<LoginResult> Login(UserForLogin userForLogin)
        {
            var checkingPasswordResult = await _signInManager.PasswordSignInAsync(userForLogin.Username, userForLogin.Password, false, false);

            if (checkingPasswordResult.Succeeded)
            {
                var user = _userManager.Users.SingleOrDefault(x => x.UserName == userForLogin.Username);
                return await GenerateJwtTokenAsync(user);
            }
            else
                return new LoginResult(false);
        }
        public async Task<ValidationErrors> ValidateUserName(string userName)
        {
            var error = "Such user already exists";
            if (await _userManager.FindByNameAsync(userName) != null)
                return new ValidationErrors (true, error);
            else
                return new ValidationErrors (false);
        }
        public async Task<ValidationErrors> ValidateEmail(string email)
        {
            var error = "Such user already exists";
            if (await _userManager.FindByEmailAsync(email) != null)
                return new ValidationErrors(true, error);
            else
                return new ValidationErrors(false);
        }
        private async Task<LoginResult> GenerateJwtTokenAsync(User user)
        {
            var userClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };

            var roles = await _userManager.GetRolesAsync(user);

            userClaims.AddRange(roles.Select(role => new Claim("role", role)));
            var claimsIdentity = new ClaimsIdentity(userClaims, "", ClaimTypes.NameIdentifier, ClaimsIdentity.DefaultRoleClaimType);
            var signinCredentials = new SigningCredentials(_authenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                 issuer: _authenticationOptions.Issuer,
                 audience: _authenticationOptions.Audience,
                 claims: userClaims,
                 expires: DateTime.Now.AddDays(30),
                 signingCredentials: signinCredentials
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            return new LoginResult(true, tokenHandler.WriteToken(jwtSecurityToken));
        }
    }
}