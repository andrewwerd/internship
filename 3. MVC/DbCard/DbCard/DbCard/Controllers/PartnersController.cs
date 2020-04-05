using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbCard.Repository;
using DbCard.Domain;
using Microsoft.Extensions.Logging;
using AutoMapper;
using DbCard.DTO;
using DbCard.Models;

namespace DbCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnersController : ControllerBase
    {
        private readonly IRepository<Partner> _repository;
        private readonly IMapper _mapper;
        public PartnersController(IRepository<Partner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        // GET: api/Partners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partner>>> GetPartners()
        {
            var partners = await _repository.GetAll();
            if (partners == null)
            {
                return NotFound();
            }
            var partnersDTO = new List<PartnerDTO>();
            foreach(var i in partners)
            {
                partnersDTO.Add(_mapper.Map<PartnerDTO>(i));
            }
            return Ok(partnersDTO);
        }

        // GET: api/Partners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Partner>> GetPartner(long id)
        {
            var partner = await _repository.GetById(id);
            if (partner == null)
            {
                return NotFound();
            }
            var partnerDto = _mapper.Map<PartnerDTO>(partner);
            return Ok(partnerDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartner(long id, PartnerForUpdateDTO partnerDto)
        {
            var partner = await _repository.GetById(id);
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
            var pagedBooksDto = await _repository.GetPagedData<PartnerDTO>(pagedRequest);
            return Ok(pagedBooksDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartner(PartnerForUpdateDTO partnerForUpdateDto)
        {
            var partner = _mapper.Map<Partner>(partnerForUpdateDto);
            await _repository.Add(partner);

            var partnerDto = _mapper.Map<PartnerDTO>(partner);

            return CreatedAtAction(nameof(GetPartner), new { id = partnerDto.Id }, partnerDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Partner>> DeletePartner(long id)
        {
            await _repository.Delete(id);
            return NoContent();
        }
    }
}
