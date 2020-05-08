using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using DbCard.Domain.Auth;
using DbCard.Infrastructure.Configuration;
using DbCard.Infrastructure.DTO.User;
using DbCard.Infrastructure.DTO.Customer;
using DbCard.Services;
using DbCard.Infrastructure.DTO.Partner;

namespace DbCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly RoleManager<Role> _roleManager;
        public AccountController(IAccountService accountService, RoleManager<Role> roleManager)
        {
            _accountService = accountService;
            _roleManager = roleManager;
        }
        // POST: api/Account
        [AllowAnonymous]
        [HttpPost("CustomerRegistration")]
        public async Task<IActionResult> CustomerRegistration(CustomerForRegistration customer)
        {
            var result = await _accountService.CustomerRegistration(customer);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost("PartnerRegistration")]
        public async Task<IActionResult> PartnerRegistration(PartnerForRegistration partner)
        {
            var result = await _accountService.PartnerRegistration(partner);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        // POST: api/Account
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLogin userForLogin)
        {
            var result = await _accountService.Login(userForLogin);
            if (result.Succeeded)
                return Ok(new { AccessToken = result.EncodedToken });
            else
                return Unauthorized();
        }
    }
}
