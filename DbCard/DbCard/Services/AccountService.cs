using DbCard.Domain.Auth;
using DbCard.Infrastructure.Configuration;
using DbCard.Infrastructure.DTO.Customer;
using DbCard.Infrastructure.DTO.Partner;
using DbCard.Infrastructure.DTO.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DbCard.Services
{
    public class AccountService : IAccountService
    {
        private readonly AuthOptions _authenticationOptions;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly CustomerService _customerService;
        private readonly PartnerService _partnerService;
        public AccountService(IOptions<AuthOptions> authenticationOptions, SignInManager<User> signInManager, UserManager<User> userManager, CustomerService customerService)
        {
            _authenticationOptions = authenticationOptions.Value;
            _signInManager = signInManager;
            _userManager = userManager;
            _customerService = customerService;
        }

        public async Task<bool> CustomerRegistration(CustomerForRegistration customerDto)
        {
            var user = new User { Email = customerDto.Email, UserName = customerDto.UserName };
            var userCreating = await _userManager.CreateAsync(user, customerDto.Password);
            if (userCreating.Succeeded)
            {
                var customerCreating = await _customerService.CreateAsync(customerDto);
                return customerCreating;
            }
            else return userCreating.Succeeded;
        }
               
        public async Task<bool> PartnerRegistration(PartnerForRegistration partnerDto)
        {
            var user = new User { Email = partnerDto.Email, UserName = partnerDto.UserName };
            var userCreating = await _userManager.CreateAsync(user, partnerDto.Password);
            if (userCreating.Succeeded)
            {
                var partnerCreating = await _partnerService.CreateAsync(partnerDto);
                return partnerCreating;
            }
            else return userCreating.Succeeded;
        }
        public async Task<LoginResult> Login(UserForLogin userForLogin)
        {
            var checkingPasswordResult = await _signInManager.PasswordSignInAsync(userForLogin.Username, userForLogin.Password, false, false);

            if (checkingPasswordResult.Succeeded)
            {
                var signinCredentials = new SigningCredentials(_authenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
                var jwtSecurityToken = new JwtSecurityToken(
                     issuer: _authenticationOptions.Issuer,
                     audience: _authenticationOptions.Audience,
                     claims: new List<Claim>(),
                     expires: DateTime.Now.AddDays(30),
                     signingCredentials: signinCredentials
                );
                var tokenHandler = new JwtSecurityTokenHandler();
                return new LoginResult(tokenHandler.WriteToken(jwtSecurityToken), true);
            }
            else return new LoginResult(false);
        }

    }
    public class LoginResult
    {
        public string EncodedToken { get; protected set; }
        public bool Succeeded { get; protected set; }
        public LoginResult(bool succeeded)
        {
            Succeeded = succeeded;
        }
        public LoginResult(string encodedToken, bool succeeded)
        {
            EncodedToken = encodedToken;
            Succeeded = succeeded;
        }
    }
}