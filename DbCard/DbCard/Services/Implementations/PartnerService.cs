using AutoMapper;
using DbCard.Domain;
using DbCard.Domain.Auth;
using DbCard.Infrastructure.Dto.Partner;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DbCard.Services
{
    class PartnerService : IPartnerService
    {
        private readonly IRepository<Category> _repositoryCategory;
        private readonly IRepository<Subcategory> _repositorySubcategory;
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Partner> _partnerRepository;
        private readonly IHttpContextAccessor _httpContext;

        public PartnerService(
            IMapper mapper,
            IRepository<Subcategory> repositorySubategory,
            IRepository<Domain.Partner> partnerRepository,
            IHttpContextAccessor httpContext,
            IRepository<Category> repositoryCategory
            )
        {
            _repositoryCategory = repositoryCategory;
            _repositorySubcategory = repositorySubategory;
            _mapper = mapper;
            _partnerRepository = partnerRepository;
            _httpContext = httpContext;
        }
        public async Task<bool> CreateAsync(Domain.Partner partner, User user)
        {
            if (partner.User == null)
            {
                partner.User = user;
                partner.UserId = user.Id;
            }
            if (partner.DateOfRegistration == null) partner.DateOfRegistration = DateTime.Now;
            if (partner.CustomersBalances == null) partner.CustomersBalances = new List<CustomersBalance>();
            if (partner.Filials == null) partner.Filials = new List<Domain.Filial>();
            if (partner.News == null) partner.News = new List<News>();
            if (partner.PremiumDiscounts == null) partner.PremiumDiscounts = new List<PremiumDiscount>();
            if (partner.StandartDiscounts == null) partner.StandartDiscounts = new List<StandartDiscount>();
            if (partner.MyCustomers == null) partner.MyCustomers = new List<FavoritePartners>();
            if (partner.Reviews == null) partner.Reviews = new List<Review>();

            try
            {
                await _partnerRepository.Add(partner);
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
        public async Task<bool> CreateFromDtoAsync(PartnerForRegistration partnerDto, User user)
        {
            var partner = _mapper.Map<Domain.Partner>(partnerDto);
            var filial = _mapper.Map<Domain.Filial>(partnerDto.Filial);
            filial.IsMainOffice = true;

            if (partner.User == null)
            {
                partner.User = user;
                partner.UserId = user.Id;
            }
            partner.DateOfRegistration = DateTime.Now;
            if (partner.CustomersBalances == null) partner.CustomersBalances = new List<CustomersBalance>();
            if (partner.Filials == null) partner.Filials = new List<Domain.Filial>();
            partner.Filials.Add(filial);
            if (partner.News == null) partner.News = new List<News>();
            if (partner.PremiumDiscounts == null) partner.PremiumDiscounts = new List<PremiumDiscount>();
            if (partner.StandartDiscounts == null) partner.StandartDiscounts = new List<StandartDiscount>();
            if (partner.MyCustomers == null) partner.MyCustomers = new List<FavoritePartners>();
            if (partner.Reviews == null) partner.Reviews = new List<Review>();

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
        public async Task AddToCategory(Domain.Partner partner, string categoryName)
        {
            var category = (await _repositoryCategory.GetByPredicate(p => p.Name == categoryName)).Single();
            partner.CategoryId = category.Id;
        }
        public async Task AddToSubcategory(Domain.Partner partner, string subcategoryName)
        {
            var subcategory = (await _repositorySubcategory.GetByPredicate(p => p.Name == subcategoryName && p.CategoryId == partner.CategoryId)).Single();
            partner.SubcategoryId = subcategory.Id;
        }

        public async Task<long> GetIdByName(string name)
        {
            return (await _partnerRepository.GetByPredicate(p => p.Name == name)).Single().Id;
        }
        public async Task<Infrastructure.Dto.Partner.Partner> GetCurrentUser()
        {
            var currentUser = _httpContext.HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var partner = (await _partnerRepository.GetByPredicate(x => x.User.Email == currentUser)).SingleOrDefault();
            var partnerDto = _mapper.Map<Infrastructure.Dto.Partner.Partner>(partner);
            return partnerDto;
        }
    }
}