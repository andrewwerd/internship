using DbCard.Domain.Auth;
using DbCard.Infrastructure.Dto.Customer;
using DbCard.Infrastructure.Dto.Partner;
using DbCard.Infrastructure.Dto.User;
using DbCard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace DbCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        // POST: api/Account/customerRegistration
        [AllowAnonymous]
        [HttpPost("customerRegistration")]
        public async Task<IActionResult> CustomerRegistration(CustomerForRegistration customer)
        {
            var result = await _accountService.CustomerRegistration(customer);
            if (result)
                return Ok();
            else
                return BadRequest();
        }
        // POST: api/Account/partnerRegistration
        [AllowAnonymous]
        [HttpPost("partnerRegistration")]
        public async Task<IActionResult> PartnerRegistration(PartnerForRegistration partner)
        {
            var result = await _accountService.PartnerRegistration(partner);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        // POST: api/Account/login
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLogin userForLogin)
        {
            var result = await _accountService.Login(userForLogin);
            if (result.Succeeded)
                return Ok(new { AccessToken = result.EncodedToken });
            else
                return Unauthorized();
        }
        [AllowAnonymous]
        [HttpPost("validateUserName")]
        public async Task<IActionResult> ValidateUserName(string userName)
        {
            var result = await _accountService.ValidateUserName(userName);
            return Ok(result);
        }
    }
}
