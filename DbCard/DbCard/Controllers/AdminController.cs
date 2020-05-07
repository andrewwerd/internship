using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbCard.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [AdminMode]
        public async Task<IActionResult> Index()
        {

           return Ok();
        }
    }
}