using System;
using DbCard.Domain;
using DbCard.Repository;

namespace DbCard.Services
{
    public class CustomerService
    {
        readonly Repository<Customer> _repository;
        readonly Repository<FavoritePartners> _favoriteRepo;
        public CustomerService(Repository<Customer> repository, Repository<FavoritePartners> favoriteRepo)
        {
            _repository = repository;
            _favoriteRepo = favoriteRepo;
        }
        public async void AddFavoritePartner(Customer customer, Partner partner)
        {
            var favoritePartner = new FavoritePartners();
            favoritePartner.Customer = customer;
            favoritePartner.Partner = partner;
            favoritePartner.CustomerId = customer.Id;
            favoritePartner.PartnerId = partner.Id;
            await _favoriteRepo.Add(favoritePartner);
        }
        public async void DeleteFavoritePartner(long customerId, long partnerId) 
        {
            var favoritePartner = _favoriteRepo.GetByPredicate(x => x.CustomerId == customerId && x.PartnerId == partnerId);
            await _favoriteRepo.Delete(favoritePartner);
        }
        //public 

    }
}
