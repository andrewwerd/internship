using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbCard.Infrastructure.Dto.Balance;
using DbCard.Infrastructure.Models;
using DbCard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DbCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IBalanceService _balanceService;

        public DiscountsController(IDiscountService discountService, IBalanceService balanceService)
        {
            _discountService = discountService;
            _balanceService = balanceService;
        }

        // GET: api/customer/myDiscounts
        [Authorize(Roles = "Customer")]
        [HttpPost("myDiscounts")]
        public async Task<IActionResult> MyDiscounts([FromBody]PagedRequest scrollRequest)
        {
            var myDiscounts = await _discountService.GetMyDiscountsPaged(scrollRequest);
            if (!myDiscounts.Any()) return NoContent();
            return Ok(myDiscounts);
        }

        [Authorize(Roles = "Customer")]
        [HttpPost("getBalancesPaged")]
        public async Task<IActionResult> GetBalancesPaged([FromBody]PagedRequest scrollRequest)
        {
            var balances = await _balanceService.GetBalancesPaged(scrollRequest);
            if (!balances.Any()) return NoContent();
            return Ok(balances);
        }
    }
}
