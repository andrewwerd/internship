using AutoMapper;
using DbCard.Infrastructure.Dto.Partner;
using DbCard.Infrastructure.Models;
using DbCard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnersController : ControllerBase
    {
        private readonly IPartnerService _partnerService;

        public PartnersController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        // GET: api/partners
        [Authorize(Roles = "Customer,Admin,Partner")]
        [HttpPost("getPagedPartners")]
        public async Task<IActionResult> GetPagedPartners([FromBody]PagedRequest scrollRequest)
        {
            var partners = await _partnerService.GetPartnerGridRows(scrollRequest);
            if (!partners.Any())
                return NoContent();
            return Ok(partners);
        }

        // GET: api/Partners/5
        [Authorize(Roles = "Customer,Admin,Partner")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartner(long id)
        {
            var partner = await _partnerService.GetPartner(id);
            if (partner == null)
                return NoContent();
            return Ok(partner);
        }

        [Authorize(Roles = "Customer,Admin,Partner")]
        [HttpGet("getFilials/{id}")]
        public async Task<IActionResult> GetFilials(long id)
        {
            var filials = await _partnerService.GetFilials(id);
            if (!filials.Any())
                return NoContent();
            return Ok(filials);
        }

        [Authorize(Roles = "Customer,Admin,Partner")]
        [HttpGet("getNews/{id}")]
        public async Task<IActionResult> GetNews(long id)
        {
            var news = await _partnerService.GetNews(id);
            if (!news.Any())
                return NoContent();
            return Ok(news);
        }
    }
}
