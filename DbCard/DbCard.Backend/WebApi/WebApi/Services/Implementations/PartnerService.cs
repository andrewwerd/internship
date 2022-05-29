using System.Security.Claims;
using Domain;
using Domain.Auth;
using WebApi.Infrastructure.Models;
using WebApi.Models.Charts;
using AutoMapper;
using Context;
using Microsoft.EntityFrameworkCore;
using WebApi.Infrastructure.DTO.Partner; 
using Partner = WebApi.Infrastructure.DTO.Partner.Partner;

namespace WebApi.Services.Implementations
{
    class PartnerService : IPartnerService
    {
        private readonly DbCardContext _context;
        private readonly IRepository<Filial> _filialRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<CustomersBalance> _customerBalancesRepository;
        private readonly IRepository<Subcategory> _subcategoryRepository;
        private readonly ICustomerService _customerService;
        private readonly IRepository<News> _newsRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Partner> _partnerRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public PartnerService(
            IMapper mapper,
            IRepository<Subcategory> subategoryRepository,
            IRepository<Domain.Partner> partnerRepository,
            DbCardContext context,
            IRepository<Filial> filialRepository,
            IRepository<News> newsRepository,
            IHttpContextAccessor contextAccessor,
            IRepository<Category> categoryRepository,
            IRepository<CustomersBalance> customerBalancesRepository,
            ICustomerService customerService
            )
        {
            _context = context;
            _filialRepository = filialRepository;
            _categoryRepository = categoryRepository;
            _customerBalancesRepository = customerBalancesRepository;
            _subcategoryRepository = subategoryRepository;
            _customerService = customerService;
            _newsRepository = newsRepository;
            _mapper = mapper;
            _partnerRepository = partnerRepository;
            _contextAccessor = contextAccessor;
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

        public async Task<Partner> GetPartner(long id)
        {
            var partner = await _partnerRepository.GetById(id);
            var partnerDto = _mapper.Map<Partner>(partner);
            var currentCustomer = await _customerService.GetCurrentCustomer();
            partnerDto.IsPremium = partner.CustomersBalances
                    .Where(x => x.CustomerId == currentCustomer.Id)
                    .Select(p => p.IsPremium)
                    .SingleOrDefault();
            return partnerDto;
        }
        public async Task<IEnumerable<Infrastructure.DTO.News.News>> GetNews(long id)
        {
            var news = await _newsRepository.GetByPredicate(x => x.PartnerId == id);
            var newsDto = news.Select(x => _mapper.Map<Infrastructure.DTO.News.News>(x));
            return newsDto;
        }
        public async Task<IEnumerable<Infrastructure.DTO.Filial.Filial>> GetFilials(long id)
        {
            var filials = await _filialRepository.GetByPredicate(x => x.PartnerId == id);
            var filialsDto = filials.Select(x => _mapper.Map<Infrastructure.DTO.Filial.Filial>(x));
            return filialsDto;
        }

        public async Task<ChartData<int>> GetWeeklyAverageStatistic()
        {
            var partner = await GetCurrentPartner();

            var query = await _context.PartnerStatistics
                .Where(transaction => transaction.PartnerId == partner.Id)
                .GroupBy(transaction => transaction.DayOfWeek)
                .Select(groupedDays => new { DayOfWeek = groupedDays.Key, Count = groupedDays.Count() })
                .ToListAsync();

            return new ChartData<int>
            {
                Labels = query.OrderBy(x => x.DayOfWeek).Select(x =>
                {
                    var day = x.DayOfWeek < 7 ? x.DayOfWeek : 0;
                    return ((DayOfWeek)day).ToString();
                }),
                Data = query.OrderBy(x => x.DayOfWeek).Select(x => x.Count)
            };
        }

        public async Task<ChartData<decimal>> GetAgeStatistic()
        {
            var partner = await GetCurrentPartner();

            var ages = new[]
            {
                "0-20",
                "20-40",
                "40-60",
                "60-80"
            };

            var query = await _context.Transactions
                .Where(transaction => transaction.Filial.PartnerId == partner.Id)
                .Select(transaction => new
                {
                    Age = (int)((DateTime.Now - transaction.Customer.DateOfBirth).TotalDays / 7300),
                    transaction
                })
                .GroupBy(x => x.Age)
                .Select(x => new
                {
                    Age = x.Key,
                    Amount = x.Sum(y => y.transaction.AllAmount)
                })
                .ToListAsync();

            return new ChartData<decimal>
            {
                Labels = ages,
                Data = query.OrderBy(x => x.Age).Select(x => x.Amount)
            };
        }

        public async Task<ChartData<int>> GetGenderStatistic()
        {
            var partner = await GetCurrentPartner();

            var query = await _context.Customers
                .Where(customer => customer.CustomersBalances.Any(balance => balance.PartnerId == partner.Id))
                .GroupBy(customer => customer.Gender)
                .Select(x => new
                {
                    Gender = x.Key,
                    Value = x.Count()
                })
                .ToListAsync();

            return new ChartData<int>
            {
                Labels = query.OrderBy(x => x.Gender).Select(x => x.Gender),
                Data = query.OrderBy(x => x.Gender).Select(x => x.Value)
            };
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

        public async Task<Partner> GetCurrentPartner()
        {
            var currentUserEmail = _contextAccessor.HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name).Value;

            var partner = (await _partnerRepository.GetByPredicate(x => x.User.Email == currentUserEmail)).SingleOrDefault();
            var partnerDto = _mapper.Map<Partner>(partner);
            return partnerDto;
        }
    }
}