using Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Infrastructure.DTO.Account;
using WebApi.Infrastructure.DTO.Customer;
using WebApi.Infrastructure.DTO.Partner;
using WebApi.Infrastructure.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private static readonly HttpClient Client = new();
        private readonly UserManager<User> _userManager;
        public AccountController(IAccountService accountService, UserManager<User> userManager)
        {
            _accountService = accountService;
            _userManager = userManager;
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
        public async Task<IActionResult> Login([FromBody] UserForLogin userForLogin)
        {
            var result = await _accountService.Login(userForLogin);
            if (result.Succeeded)
                return Ok(new { AccessToken = result.EncodedToken });
            else
                return Unauthorized();
        }

        // POST: api/Account/login-facebook
        [AllowAnonymous]
        [HttpPost("login-facebook")]
        public async Task<IActionResult> LoginFacebook([FromBody] FacebookAuthViewModel model)
        {
            var appId = "757377755621029";
            var appSecret = "f4ba2d766f85c25579b6b5bfa850060d";
            // 1.generate an app access token
            var appAccessTokenResponse = await Client.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id={appId}&client_secret={appSecret}&grant_type=client_credentials");
            var appAccessToken = JsonConvert.DeserializeObject<FacebookAppAccessToken>(appAccessTokenResponse);
            // 2. validate the user access token
            var userAccessTokenValidationResponse = await Client.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={model.AccessToken}&access_token={appAccessToken.AccessToken}");
            var userAccessTokenValidation = JsonConvert.DeserializeObject<FacebookUserAccessTokenValidation>(userAccessTokenValidationResponse);

            if (!userAccessTokenValidation.Data.IsValid)
            {
                return Unauthorized();
            }

            // 3. we've got a valid token so we can request user data from fb
            var userInfoResponse = await Client.GetStringAsync($"https://graph.facebook.com/v2.8/me?fields=id,email,first_name,last_name,name,gender,locale,birthday,picture&access_token={model.AccessToken}");
            var userInfo = JsonConvert.DeserializeObject<FacebookUserData>(userInfoResponse);

            // 4. ready to create the local user account (if necessary) and jwt

            // generate the jwt for the local user...
            var localUser = await _userManager.FindByNameAsync("customer1");

            var jwt = await _accountService.GenerateJwtTokenAsync(localUser);

            return Ok(new { AccessToken = jwt.EncodedToken });
        }


        [AllowAnonymous]
        [HttpGet("validateUserName")]
        public async Task<IActionResult> ValidateUserName([FromQuery] string userName)
        {
            var result = await _accountService.ValidateUserName(userName);
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet("validateEmail")]
        public async Task<IActionResult> ValidateEmail([FromQuery] string email)
        {
            var result = await _accountService.ValidateEmail(email);
            return Ok(result);
        }
        [Authorize(Roles = "Customer,Partner,Admin")]
        [HttpGet("checkPassword")]
        public async Task<IActionResult> CheckPassword([FromQuery] string password)
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
