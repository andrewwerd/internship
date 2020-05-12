﻿using DbCard.Domain.Auth;
using DbCard.Infrastructure.Configuration;
using DbCard.Infrastructure.Dto.Customer;
using DbCard.Infrastructure.Dto.Partner;
using DbCard.Infrastructure.Dto.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
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
            var user = new User { Email = customerDto.Email, UserName = customerDto.UserName };
            var userCreating = await _userManager.CreateAsync(user, customerDto.Password);
            if (userCreating.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
                var customerCreating = await _customerService.CreateAsync(customerDto);
                return customerCreating;
            }
            else
                return userCreating.Succeeded;
        }

        public async Task<bool> PartnerRegistration(PartnerForRegistration partnerDto)
        {
            var user = new User { Email = partnerDto.Email, UserName = partnerDto.UserName };
            var userCreating = await _userManager.CreateAsync(user, partnerDto.Password);
            if (userCreating.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Partner");
                var partnerCreating = await _partnerService.CreateAsync(partnerDto);
                return partnerCreating;
            }
            else
                return userCreating.Succeeded;
        }
        public async Task<LoginResult> Login(UserForLogin userForLogin)
        {
            var checkingPasswordResult = await _signInManager.PasswordSignInAsync(userForLogin.Username, userForLogin.Password, false, false);

            if(checkingPasswordResult.Succeeded)
            {
                var user = _userManager.Users.SingleOrDefault(x => x.UserName == userForLogin.Username);
                return await GenerateJwtTokenAsync(user);
            }
            else
                return new LoginResult(false);
        }
        private async Task<LoginResult> GenerateJwtTokenAsync(User user)
        {
            var userClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var roles = await _userManager.GetRolesAsync(user);

            userClaims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            var signinCredentials = new SigningCredentials(_authenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                 issuer: _authenticationOptions.Issuer,
                 audience: _authenticationOptions.Audience,
                 claims: userClaims,
                 expires: DateTime.Now.AddDays(30),
                 signingCredentials: signinCredentials
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            return new LoginResult(tokenHandler.WriteToken(jwtSecurityToken), true);
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