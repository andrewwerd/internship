using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Infrastructure.Configuration;
using WebApi.Infrastructure.DTO.Account;
using WebApi.Infrastructure.DTO.Customer;
using WebApi.Infrastructure.DTO.Partner;
using WebApi.Infrastructure.Models; 

namespace WebApi.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly AuthOptions _authenticationOptions;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly ICustomerService _customerService;
        private readonly IPartnerService _partnerService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public AccountService(
            IHttpContextAccessor contextAccessor,
            IOptions<AuthOptions> authenticationOptions,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            ICustomerService customerService,
            IPartnerService partnerService,
            IMapper mapper)
        {
            _authenticationOptions = authenticationOptions.Value;
            _signInManager = signInManager;
            _userManager = userManager;
            _customerService = customerService;
            _partnerService = partnerService;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
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
            var user = new User { Email = partnerDto.Email, UserName = partnerDto.UserName, PhoneNumber = partnerDto.PhoneNumber };
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
                return new ValidationErrors(true, error);
            else
                return new ValidationErrors(false);
        }
        public async Task<ValidationErrors> ValidateEmail(string email)
        {
            var error = "Such user already exists";
            if (await _userManager.FindByEmailAsync(email) != null)
                return new ValidationErrors(true, error);
            else
                return new ValidationErrors(false);
        }
        public async Task<ValidationErrors> CheckPassword(string password)
        {
            var currentUser = await GetCurrentUser();
            var error = "Wrong password";
            if (!await _userManager.CheckPasswordAsync(currentUser, password))
                return new ValidationErrors(true, error);
            else
                return new ValidationErrors(false);
        }
        public async Task<UserForEdit> GetCurrentUserDto()
        {
            var currentUser = await GetCurrentUser();
            var currentUserDto = new UserForEdit();
            _mapper.Map(currentUser, currentUserDto);
            return currentUserDto;
        }

        private async Task<User> GetCurrentUser()
        {
            var currentUserEmail = _contextAccessor.HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name).Value;

            return await _userManager.FindByEmailAsync(currentUserEmail);
        }

        public async Task<LoginResult> GenerateJwtTokenAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var userClaims = new List<Claim>
            {
                new Claim("email", user.Email),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            userClaims.AddRange(roles.Select(role => new Claim("role", role)));

            var isCustomer = roles.Any(role => role == "Customer");
            if (isCustomer)
            {
                var customer = await _customerService.GetByNameAsync(user.UserName);
                userClaims.Add(new Claim("firstName", customer.FirstName));
                userClaims.Add(new Claim("lastName", customer.LastName));
            }

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

        public async Task<bool> EditUser(UserForEdit userForEdit)
        {
            var currentUser = await GetCurrentUser();
            _mapper.Map(userForEdit, currentUser);
            var updateResult = await _userManager.UpdateAsync(currentUser);
            return updateResult.Succeeded;
        }
        public async Task<bool> EditPassword(PasswordForEdit passwordForEdit)
        {
            var currentUser = await GetCurrentUser();
            var updateResult = await _userManager.ChangePasswordAsync(currentUser, passwordForEdit.CurrentPassword, passwordForEdit.NewPassword);
            return updateResult.Succeeded;
        }
    }
}