using AutoMapper;
using DbCard.Domain;
using DbCard.Infrastructure.Dto.Partner;
using System;
using System.Threading.Tasks;

namespace DbCard.Services
{
    class PartnerService : IPartnerService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Partner> _partnerRepository;

        public PartnerService(IMapper mapper, IRepository<Domain.Partner> partnerRepository)
        {
            _mapper = mapper;
            _partnerRepository = partnerRepository;
        }
        public async Task<bool> CreateAsync(PartnerForRegistration partnerDto)
        {
            var partner = _mapper.Map<Domain.Partner>(partnerDto);
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