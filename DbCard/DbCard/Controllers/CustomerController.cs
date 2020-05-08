using DbCard.Domain.Auth;
using DbCard.Infrastructure.DTO.Balance;
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

        // GET: api/Customer/MyDiscounts
        [Authorize(Roles = "Customer")]
        [HttpGet("MyDiscounts")]
        public async Task<ActionResult<IEnumerable<PremiumBalanceDto>>> MyDiscounts(long id)
        {
            var myDiscounts = await _customerService.MyDiscounts(id);
            if (myDiscounts == null) return NoContent();
            return Ok(await _customerService.MyDiscounts(id));
        }
        //GET: api/Customer/id/
    }
}