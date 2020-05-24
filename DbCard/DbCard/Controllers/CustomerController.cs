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

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Authorize(Roles = "Customer")]
        [HttpGet("currentCustomer")]
        public async Task<ActionResult<object>> GetCurrentCustomer()
        {
            var customer = await _customerService.GetCurrentCustomerDto();
            if (customer != null)
                return Ok(customer);
            else
                return NotFound();
        }
        [Authorize(Roles = "Customer")]
        [HttpPut]
        public async Task<ActionResult<object>> EditCustomer(Infrastructure.Dto.Customer.Customer customerDto)
        {
            var result = await _customerService.EditCustomer(customerDto);
            return Ok(result);
        }
    }
}