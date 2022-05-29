using System.Security.Claims;
using AutoMapper;
using Domain;
using Domain.Auth;
using WebApi.Infrastructure.DTO.Customer;
using WebApi.Infrastructure.Extensions; 
using Customer = WebApi.Infrastructure.DTO.Customer.Customer;

namespace WebApi.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Domain.Customer> _customerRepository;
        private readonly IRepository<FavoritePartners> _favoritePartnersRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public CustomerService(
            IMapper mapper,
            IRepository<Domain.Customer> customerRepository,
            IRepository<FavoritePartners> favoriteRepo,
            IHttpContextAccessor contextAccessor
            )
        {
            _customerRepository = customerRepository;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
            _favoritePartnersRepository = favoriteRepo;
        }

        public async Task<bool> CreateAsync(Domain.Customer customer, User user)
        {
            if (customer.UserId == 0)
            {
                customer.UserId = user.Id;
            }
            if (customer.DateOfBirth == null) customer.DateOfBirth = default;

            customer.DateOfRegistration = DateTime.Now;
            customer.Barcode = customer.Barcode ?? Guid.NewGuid().NewShortGuid();
            customer.Gender = customer.Gender ?? "Male";
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

            if (customer.UserId == 0) customer.UserId = user.Id;
            customer.DateOfRegistration = DateTime.Now;
            customer.Barcode = customer.Barcode ?? Guid.NewGuid().NewShortGuid();
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
            var favoritePartners = await _favoritePartnersRepository.GetByPredicate(x => x.Partner.Id == partnerId && x.CustomerId == customerId);
            var favoritePartner = favoritePartners.Single();
            await _favoritePartnersRepository.Delete(favoritePartner);
        }

        public async Task<Customer> GetCurrentCustomerDto()
        {
            var customer = await GetCurrentCustomer();
            var customerDto = _mapper.Map<Customer>(customer);

            return customerDto;
        }
        public async Task<Domain.Customer> GetCurrentCustomer()
        {
            var currentUserEmail = _contextAccessor.HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name).Value;
            var customers = await _customerRepository.GetByPredicate(x => x.User.Email == currentUserEmail);
            var customer = customers.SingleOrDefault();

            return customer;
        }
        public async Task<Domain.Customer> GetByNameAsync(string userName)
        {
            var customer = await _customerRepository.GetByPredicate(p => p.User.UserName == userName);
            return customer.Single();
        }

        public async Task<bool> EditCustomer(Customer customerDto)
        {
            var customer = await GetCurrentCustomer();
            _mapper.Map(customerDto, customer);
            try
            {
                await _customerRepository.Update(customer);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
