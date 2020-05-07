using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DbCard.Domain;
using DbCard.Infrastructure.DTO.Partner;
using DbCard.Repository;
using DbCard.Services.Interfaces;

namespace DbCard.Services
{
    class PartnerService : IPartnerService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Partner> _partnerRepository;

        public PartnerService(IMapper mapper, IRepository<Partner> partnerRepository)
        {
            _mapper = mapper;
            _partnerRepository = partnerRepository;
        }
        public async Task<bool> CreateAsync(PartnerForRegistration partnerDto)
        {
            var partner = _mapper.Map<Partner>(partnerDto);
            try
            {
                await _partnerRepository.Add(partner);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}