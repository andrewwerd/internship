using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbCard.Infrastructure.Dto.Balance;
using DbCard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        // GET: api/customer/myDiscounts
        [Authorize(Roles = "Customer")]
        [HttpGet("myDiscounts")]
        public async Task<IActionResult> MyDiscounts([FromQuery] string barcode )
        {
            var myDiscounts = await _discountService.GetMyDiscounts(barcode);
            if (!myDiscounts.Any()) return NoContent();
            return Ok(myDiscounts);
        }
    }
}
