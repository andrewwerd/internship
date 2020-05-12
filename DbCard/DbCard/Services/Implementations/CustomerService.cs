using AutoMapper;
using DbCard.Domain;
using DbCard.Infrastructure.Dto.Balance;
using DbCard.Infrastructure.Dto.Customer;
using DbCard.Infrastructure.Dto.Partner;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbCard.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        readonly IRepository<Domain.Customer> _repository;
        readonly IRepository<FavoritePartners> _favoriteRepo;
        readonly IRepository<CustomersBalance> _balanceRepo;
        readonly IMapper _mapper;
        public CustomerService(IMapper mapper, IRepository<Customer> repository, IRepository<FavoritePartners> favoriteRepo, IRepository<CustomersBalance> balanceRepo)
        {
            _balanceRepo = balanceRepo;
            _repository = repository;
            _mapper = mapper;
            _favoriteRepo = favoriteRepo;
        }
        public async Task<bool> CreateAsync(CustomerForRegistration customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
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
    }
}
