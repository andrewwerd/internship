using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnersController : ControllerBase
    {
        Repository<Partner> _repository;
        public PartnersController(Repository<Partner> repo)
        {
            _repository = repo;
        }
        [HttpGet]
        public IEnumerable<Partner> Get()
        {
            return _repository.Get();
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Partner>> Get(int id)
        {
            var partner = await _repository.FindByIdAsync(id);
            if (partner == null) 
                return NotFound();
            return new ObjectResult(partner);
        }

        [HttpPost]
        public async Task<ActionResult<Partner>> Post(Partner partner)
        {
            if(partner == null)
            {
                return BadRequest();
            }
            await _repository.AddAsync(partner);
            return Ok(partner);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Partner>> Put(Partner partner)
        {
            if(partner == null)
            {
                return BadRequest();
            }
            if (_repository.FindById(partner.Id) == null)
            {
                return NotFound();
            }
            await _repository.UpdateAsync(partner);
            return Ok(partner);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Partner>> Delete(int id)
        {
            var partner = _repository.FindById(id);
            if (partner == null)
            {
                return NotFound();
            }
            await _repository.RemoveAsync(partner);
            return Ok(partner);
        }
    }
}
