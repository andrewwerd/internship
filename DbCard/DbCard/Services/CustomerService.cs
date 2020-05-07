using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DbCard.Domain;
using DbCard.Infrastructure.DTO.Balance;
using DbCard.Infrastructure.DTO.Customer;
using DbCard.Infrastructure.DTO.Partner;
using DbCard.Repository;

namespace DbCard.Services
{
    public class CustomerService
    {
        readonly IRepository<Customer> _repository;
        readonly IRepository<FavoritePartners> _favoriteRepo;
        readonly IRepository<CustomersBalance> _balanceRepo;
        readonly IMapper _mapper;
        public CustomerService(IMapper mapper, IRepository<Customer> repository, IRepository<FavoritePartners> favoriteRepo)
        {
            _repository = repository;
            _mapper = mapper;
            _favoriteRepo = favoriteRepo;
        }
        public async Task<bool> CreateCustomer(CustomerDto customerDto)
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
        public async Task<bool> UpdateCustomer(long id, CustomerDto customerDto)
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
        public async Task<IEnumerable<PremiumBalanceDto>> MyDiscounts(long id)
        {
            var balances = await _balanceRepo.GetByPredicate(x => x.IsPremium && x.CustomerId == id);
            var balancesDto = new List<PremiumBalanceDto>();
            foreach (var i in balances)
            {
                balancesDto.Add(_mapper.Map<PremiumBalanceDto>(i));
            }
            return balancesDto;
        }
        public async void AddFavoritePartner(long id, PartnerDto partnerDto)
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
            var favoritePartner = await _favoriteRepo.GetByPredicate(x => x.CustomerId == customerId && x.PartnerId == partnerId);
            await _favoriteRepo.Delete(favoritePartner);
        }
    }
}
