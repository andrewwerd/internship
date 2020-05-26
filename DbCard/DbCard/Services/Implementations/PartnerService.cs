using AutoMapper;
using DbCard.Domain;
using DbCard.Domain.Auth;
using DbCard.Infrastructure.Dto.Partner;
using DbCard.Infrastructure.Models;
using DbCard.Services.Implementations;
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
        private readonly IRepository<Filial> _filialRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<CustomersBalance> _customerBalancesRepository;
        private readonly IRepository<Subcategory> _subcategoryRepository;
        private readonly ICustomerService _customerService;
        private readonly IRepository<News> _newsRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Partner> _partnerRepository;
        private readonly IHttpContextAccessor _httpContext;

        public PartnerService(
            IMapper mapper,
            IRepository<Subcategory> subategoryRepository,
            IRepository<Domain.Partner> partnerRepository,
            IRepository<Domain.Filial> filialRepository,
            IRepository<Domain.News> newsRepository,
            IHttpContextAccessor httpContext,
            IRepository<Category> categoryRepository,
            IRepository<CustomersBalance> customerBalancesRepository,
            ICustomerService customerService
            )
        {
            _filialRepository = filialRepository;
            _categoryRepository = categoryRepository;
            _customerBalancesRepository = customerBalancesRepository;
            _subcategoryRepository = subategoryRepository;
            _customerService = customerService;
            _newsRepository = newsRepository;
            _mapper = mapper;
            _partnerRepository = partnerRepository;
            _httpContext = httpContext;
        }

        public async Task<IEnumerable<PartnerGridRow>> GetPartnerGridRows(PagedRequest scrollRequest)
        {
            var partners = await _partnerRepository.GetScrollData<PartnerGridRow>(scrollRequest);
            var currentCustomer = await _customerService.GetCurrentCustomer();
            foreach (var item in partners)
            {
                item.IsPremium = _customerBalancesRepository
                    .Get()
                    .Where(x => x.CustomerId == currentCustomer.Id && x.PartnerId == item.Id)
                    .Select(p => p.IsPremium)
                    .SingleOrDefault();
            } 
            return partners;
        }

        public async Task<Infrastructure.Dto.Partner.Partner> GetPartner(long id)
        {
            var partner = await _partnerRepository.GetById(id);
            var partnerDto = _mapper.Map<Infrastructure.Dto.Partner.Partner>(partner);
            var currentCustomer = await _customerService.GetCurrentCustomer();
            partnerDto.IsPremium = partner.CustomersBalances
                    .Where(x => x.CustomerId == currentCustomer.Id)
                    .Select(p => p.IsPremium)
                    .SingleOrDefault();
            return partnerDto;
        }
        public async Task<IEnumerable<Infrastructure.Dto.News.News>> GetNews(long id)
        {
            var news = await _newsRepository.GetByPredicate(x => x.PartnerId == id);
            var newsDto = news.Select(x => _mapper.Map<Infrastructure.Dto.News.News>(x));
            return newsDto;
        }
        public async Task<IEnumerable<Infrastructure.Dto.Filial.Filial>> GetFilials(long id)
        {
            var filials = await _filialRepository.GetByPredicate(x => x.PartnerId == id);
            var filialsDto = filials.Select(x => _mapper.Map<Infrastructure.Dto.Filial.Filial>(x));
            return filialsDto;
        }

        public async Task<bool> CreateAsync(Domain.Partner partner, User user)
        {

            partner.UserId = user.Id;
            partner.DateOfRegistration = DateTime.Now;
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

            partner.UserId = user.Id;
            partner.DateOfRegistration = DateTime.Now;
            partner.Filials = new List<Filial>() { filial };
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
            var category = (await _categoryRepository.GetByPredicate(p => p.Name == categoryName)).Single();
            partner.CategoryId = category.Id;
        }

        public async Task AddToSubcategory(Domain.Partner partner, string subcategoryName)
        {
            var subcategory = (await _subcategoryRepository.GetByPredicate(p => p.Name == subcategoryName && p.CategoryId == partner.CategoryId)).Single();
            partner.SubcategoryId = subcategory.Id;
        }

        public async Task<long> GetIdByName(string name)
        {
            return (await _partnerRepository.GetByPredicate(p => p.Name == name)).Single().Id;
        }

        public async Task<Infrastructure.Dto.Partner.Partner> GetCurrentPartner()
        {
            var currentUser = _httpContext.HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var partner = (await _partnerRepository.GetByPredicate(x => x.User.Email == currentUser)).SingleOrDefault();
            var partnerDto = _mapper.Map<Infrastructure.Dto.Partner.Partner>(partner);
            return partnerDto;
        }
    }
}