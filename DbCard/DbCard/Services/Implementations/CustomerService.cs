using AutoMapper;
using DbCard.Domain;
using DbCard.Domain.Auth;
using DbCard.Infrastructure.Dto.Balance;
using DbCard.Infrastructure.Dto.Customer;
using DbCard.Infrastructure.Dto.Partner;
using DbCard.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DbCard.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        readonly IRepository<Domain.Customer> _repository;
        readonly IRepository<FavoritePartners> _favoriteRepo;
        readonly IRepository<CustomersBalance> _balanceRepo;
        private readonly IHttpContextAccessor _context;

        readonly IMapper _mapper;
        public CustomerService( IHttpContextAccessor context, IMapper mapper, IRepository<Domain.Customer> repository, IRepository<FavoritePartners> favoriteRepo, IRepository<CustomersBalance> balanceRepo)
        {
            _balanceRepo = balanceRepo;
            _repository = repository;
            _context = context;
            _mapper = mapper;
            _favoriteRepo = favoriteRepo;
        }
        public async Task<bool> CreateAsync (Domain.Customer customer, User user)
        {
            if (customer.User == null)
            {
                customer.User = user;
                customer.UserId = user.Id;
            }
            if (customer.DateOfBirth == null) customer.DateOfBirth = default;
            if (customer.Barcode == null) customer.Barcode = Guid.NewGuid().NewShortGuid();
            if (customer.Gender == null) customer.Gender = "Male";
            if (customer.PhoneNumber == null) customer.PhoneNumber = "067729269";
            if (customer.Transactions == null) customer.Transactions = new List<Transaction>();
            if (customer.FavoritePartners == null) customer.FavoritePartners = new List<FavoritePartners>();
            if (customer.CustomersBalances == null) customer.CustomersBalances = new List<CustomersBalance>();
            if (customer.Reviews == null) customer.Reviews = new List<Review>();
            try
            {
                await _repository.Add(customer);
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> MapAsync(CustomerForRegistration customerDto)
        {
            var customer = _mapper.Map<Domain.Customer>(customerDto);
            try
            {
                await _repository.Add(customer);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> UpdateAsync(long id, CustomerForRegistration customerDto)
        {
            var customer = await _repository.GetById(id);
            _mapper.Map(customer, customerDto);
            try
            {
                await _repository.SaveAll();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public async Task<IEnumerable<PremiumBalance>> MyDiscounts(long id)
        {
            var balances = await _balanceRepo.GetByPredicate(x => x.IsPremium && x.CustomerId == id);
            var balancesDto = new List<PremiumBalance>();
            foreach (var i in balances)
            {
                balancesDto.Add(_mapper.Map<PremiumBalance>(i));
            }
            return balancesDto;
        }
        public async void AddFavoritePartner(long id, PartnerGridRow partnerDto)
        {
            var favoritePartner = new FavoritePartners();
            var customer = await _repository.GetById(id);
            var partner = _mapper.Map<Partner>(partnerDto);
            favoritePartner.Customer = customer;
            favoritePartner.Partner = partner;
            favoritePartner.CustomerId = customer.Id;
            favoritePartner.PartnerId = partner.Id;
            partner.MyCustomers.Add(favoritePartner);
            customer.FavoritePartners.Add(favoritePartner);
            await _favoriteRepo.Add(favoritePartner);

        }
        public async void DeleteFavoritePartner(long customerId, long partnerId)
        {
        }

        public async Task<Infrastructure.Dto.Customer.Customer> GetCurrentUser()
        {
            var currentUser = _context.HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var customer = (await _repository.GetByPredicate(x => x.User.Email == currentUser)).SingleOrDefault();
            var customerDto = _mapper.Map<Infrastructure.Dto.Customer.Customer>(customer);
            return customerDto;
        }

        public async Task<IEnumerable<Domain.Customer>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
