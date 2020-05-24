using DbCard.Infrastructure.Dto.Account;
using DbCard.Infrastructure.Dto.Customer;
using DbCard.Infrastructure.Dto.Partner;
using DbCard.Infrastructure.Dto.User;
using DbCard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(result);
        }
        // POST: api/Account/partnerRegistration
        [AllowAnonymous]
        [HttpPost("partnerRegistration")]
        public async Task<IActionResult> PartnerRegistration(PartnerForRegistration partner)
        {
            var result = await _accountService.PartnerRegistration(partner);
            return Ok(result);
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
        [HttpGet("validateUserName")]
        public async Task<IActionResult> ValidateUserName([FromQuery]string userName)
        {
            var result = await _accountService.ValidateUserName(userName);
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet("validateEmail")]
        public async Task<IActionResult> ValidateEmail([FromQuery]string email)
        {
            var result = await _accountService.ValidateEmail(email);
            return Ok(result);
        }
        [Authorize(Roles = "Customer,Partner,Admin")]
        [HttpGet("checkPassword")]
        public async Task<IActionResult> CheckPassword([FromQuery]string password)
        {
            var result = await _accountService.CheckPassword(password);
            return Ok(result);
        }
        [Authorize(Roles = "Customer,Partner,Admin")]
        [HttpPut("editUser")]
        public async Task<IActionResult> EditUser(UserForEdit userForEdit)
        {
            var result = await _accountService.EditUser(userForEdit);
            return Ok(result);
        }
        [Authorize(Roles = "Customer,Partner,Admin")]
        [HttpPut("editPassword")]
        public async Task<IActionResult> EditPassword(PasswordForEdit passwordForEdit)
        {
            var result = await _accountService.EditPassword(passwordForEdit);
            return Ok(result);
        }
        [Authorize(Roles = "Customer,Partner,Admin")]
        [HttpGet("getCurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var result = await _accountService.GetCurrentUserDto();
            return Ok(result);
        }
    }
}
