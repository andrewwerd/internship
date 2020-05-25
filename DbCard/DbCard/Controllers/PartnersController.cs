using AutoMapper;
using DbCard.Infrastructure.Dto.Partner;
using DbCard.Infrastructure.Models;
using DbCard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            if (partners == null)
            {
                return NotFound();
            }
            return Ok(partners);
        }

        // GET: api/Partners/5
        [Authorize(Roles = "Customer,Admin,Partner")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartner(long id)
        {
            var partner = await _partnerService.GetPartner(id);
            if (partner == null)
            {
                return Ok(partner);
            }
            return NotFound();
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPartner(PartnerForUpdate partnerDto)
        //{
        //    var partner = await _repository.GetById(partnerDto.Id);
        //    if (partner == null)
        //    {
        //        return NotFound();
        //    }
        //    _mapper.Map(partnerDto, partner);
        //    await _repository.SaveAll();
        //    return NoContent();
        //}



        //[HttpPost]
        //public async Task<IActionResult> CreatePartner(PartnerForRegistration partnerForUpdateDto)
        //{
        //    var partner = _mapper.Map<Domain.Partner>(partnerForUpdateDto);
        //    await _repository.Add(partner);

        //    var partnerDto = _mapper.Map<Infrastructure.Dto.Partner.Partner>(partner);

        //    return CreatedAtAction(nameof(GetPartner), new { id = partnerDto.Id }, partnerDto);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Domain.Partner>> DeletePartner(long id)
        //{
        //    await _repository.Delete(id);
        //    return NoContent();
        //}
    }
}
