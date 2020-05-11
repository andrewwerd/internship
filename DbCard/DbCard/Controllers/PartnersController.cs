using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbCard.Services;
using DbCard.Domain;
using Microsoft.Extensions.Logging;
using AutoMapper;
using DbCard.Infrastructure.Dto.Partner;
using DbCard.Models;

namespace DbCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnersController : ControllerBase
    {
        private readonly IRepository<Domain.Partner> _repository;
        private readonly IMapper _mapper;
        public PartnersController(IRepository<Domain.Partner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        // GET: api/Partners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Partner>>> GetPartners()
        {
            var partners = await _repository.GetAll();
            if (partners == null)
            {
                return NotFound();
            }
            var partnersDto = new List<Infrastructure.Dto.Partner.Partner>();
            foreach(var i in partners)
            {
                partnersDto.Add(_mapper.Map<Infrastructure.Dto.Partner.Partner>(i));
            }
            return Ok(partnersDto);
        }

        // GET: api/Partners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Partner>> GetPartner(long id)
        {
            var partner = await _repository.GetById(id);
            if (partner == null)
            {
                return NotFound();
            }
            var partnerDto = _mapper.Map<Infrastructure.Dto.Partner.Partner>(partner);
            return Ok(partnerDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartner(PartnerForUpdate partnerDto)
        {
            var partner = await _repository.GetById(partnerDto.Id);
            if(partner == null)
            {
                return NotFound();
            }
            _mapper.Map(partnerDto, partner);
            await _repository.SaveAll();
            return NoContent();
        }

        [HttpPost("PaginatedSearch")]
        public async Task<IActionResult> GetPagedPartners([FromBody]PagedRequest pagedRequest)
        {
            var pagedBooksDto = await _repository.GetPagedData<Infrastructure.Dto.Partner.Partner>(pagedRequest);
            return Ok(pagedBooksDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartner(PartnerForRegistration partnerForUpdateDto)
        {
            var partner = _mapper.Map<Domain.Partner>(partnerForUpdateDto);
            await _repository.Add(partner);

            var partnerDto = _mapper.Map<Infrastructure.Dto.Partner.Partner>(partner);

            return CreatedAtAction(nameof(GetPartner), new { id = partnerDto.Id }, partnerDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Domain.Partner>> DeletePartner(long id)
        {
            await _repository.Delete(id);
            return NoContent();
        }
    }
}
