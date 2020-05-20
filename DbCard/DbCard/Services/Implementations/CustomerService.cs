using AutoMapper;
using DbCard.Domain;
using DbCard.Domain.Auth;
using DbCard.Infrastructure.Dto.Customer;
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
        private readonly IRepository<Domain.Customer> _customerRepository;
        private readonly IRepository<FavoritePartners> _favoritePartnersRepository;
        private readonly IHttpContextAccessor _context;
        private readonly IMapper _mapper;

        public CustomerService(
            IHttpContextAccessor context,
            IMapper mapper,
            IRepository<Domain.Customer> customerRepository,
            IRepository<FavoritePartners> favoriteRepo
            )
        {
            _customerRepository = customerRepository;
            _context = context;
            _mapper = mapper;
            _favoritePartnersRepository = favoriteRepo;
        }

        public async Task<bool> CreateAsync(Domain.Customer customer, User user)
        {
            if (customer.User == null)
            {
                customer.User = user;
                customer.UserId = user.Id;
            }
            if (customer.DateOfBirth == null) customer.DateOfBirth = default;
            customer.DateOfRegistration = DateTime.Now;
            if (customer.Barcode == null) customer.Barcode = Guid.NewGuid().NewShortGuid();
            if (customer.Gender == null) customer.Gender = "Male";
            if (customer.Transactions == null) customer.Transactions = new List<Transaction>();
            if (customer.FavoritePartners == null) customer.FavoritePartners = new List<FavoritePartners>();
            if (customer.CustomersBalances == null) customer.CustomersBalances = new List<CustomersBalance>();
            if (customer.Reviews == null) customer.Reviews = new List<Review>();
            try
            {
                await _customerRepository.Add(customer);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CreateFromDtoAsync(CustomerForRegistration customerDto, User user)
        {
            var customer = _mapper.Map<Domain.Customer>(customerDto);
            if (customer.User == null)
            {
                customer.User = user;
                customer.UserId = user.Id;
            }
            if (customer.DateOfBirth == null) customer.DateOfBirth = new DateTime(customerDto.DateOfBirth);
            customer.DateOfRegistration = DateTime.Now;
            if (customer.Barcode == null) customer.Barcode = Guid.NewGuid().NewShortGuid();
            if (customer.Gender == null) customer.Gender = "Male";
            if (customer.Transactions == null) customer.Transactions = new List<Transaction>();
            if (customer.FavoritePartners == null) customer.FavoritePartners = new List<FavoritePartners>();
            if (customer.CustomersBalances == null) customer.CustomersBalances = new List<CustomersBalance>();
            if (customer.Reviews == null) customer.Reviews = new List<Review>();
            try
            {
                await _customerRepository.Add(customer);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateAsync(long id, CustomerForRegistration customerDto)
        {
            var customer = await _customerRepository.GetById(id);
            _mapper.Map(customer, customerDto);
            try
            {
                await _customerRepository.SaveAll();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async void AddFavoritePartner(long customerId, long partnerId)
        {
            if (_favoritePartnersRepository.Any(x => x.Partner.Id == partnerId && x.CustomerId == customerId))
                return;
            var favoritePartner = new FavoritePartners()
            {
                CustomerId = customerId,
                PartnerId = partnerId
            };
            await _favoritePartnersRepository.Add(favoritePartner);
        }

        public async void DeleteFavoritePartner(long customerId, long partnerId)
        {
            var favoritePartner = (await _favoritePartnersRepository.GetByPredicate(x => x.Partner.Id == partnerId && x.CustomerId == customerId)).Single();
            await _favoritePartnersRepository.Delete(favoritePartner);
        }

        public async Task<Infrastructure.Dto.Customer.Customer> GetCurrentUser()
        {
            var currentUser = _context.HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var customer = (await _customerRepository.GetByPredicate(x => x.User.Email == currentUser)).SingleOrDefault();
            var customerDto = _mapper.Map<Infrastructure.Dto.Customer.Customer>(customer);
            return customerDto;
        }

        public async Task<Domain.Customer> GetByName(string userName)
        {
            return (await _customerRepository.GetByPredicate(p => p.User.UserName == userName)).Single();
        }
    }
}
