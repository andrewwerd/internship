using DbCard.Domain.Auth;
using DbCard.Infrastructure.Dto.Balance;
using DbCard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly RoleManager<Role> _roleManager;

        public CustomerController(ICustomerService customerService, RoleManager<Role> roleManager)
        {
            _customerService = customerService;
            _roleManager = roleManager;
        }

        // GET: api/customer/myDiscounts
        [Authorize(Roles = "Customer")]
        [HttpGet("myDiscounts")]
        public async Task<ActionResult<IEnumerable<PremiumBalance>>> MyDiscounts(long id)
        {
            var myDiscounts = await _customerService.MyDiscounts(id);
            if (myDiscounts == null) return NoContent();
            return Ok(await _customerService.MyDiscounts(id));
        }
        [Authorize(Roles = "Customer")]
        [HttpGet("currentUser")]
        public async Task<ActionResult<object>> GetCurrentUser()
        {
            var customer = await _customerService.GetCurrentUser();
            if (customer != null)
                return Ok(customer);
            else
                return NotFound();
        }
    }
}