using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using DbCard.Infrastructure.DTO.Balance;
using DbCard.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService) => _customerService = customerService;

        // GET: api/Customer/id/myDiscounts
        [HttpGet("id/myDiscounts")]
        public async Task<ActionResult<IEnumerable<PremiumBalanceDto>>> MyDiscounts(long id)
        {
            var myDiscounts = await _customerService.MyDiscounts(id);
            if (myDiscounts == null) return NoContent();
            return Ok(await _customerService.MyDiscounts(id));
        }
        //GET: api/Customer/id/
    }
}