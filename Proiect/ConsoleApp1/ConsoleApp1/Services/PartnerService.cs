using System;
using System.Collections.Generic;
using Proiect.Models;
using Proiect.Repository;

namespace Proiect.Services
{
    class PartnerService
    {
        private Repository<Partner> _partnerRepository;

        public PartnerService()
        {
            _partnerRepository = Repository<Partner>.Instance;
        }
        public void Create(string name, string category, string address, string phoneNumber, string description = "", decimal rating = 0, string logo = "")
        {
            var partner = new Partner();

            partner.Id = Guid.NewGuid();
            partner.Logo = logo;
            partner.Category = category;
            partner.Name = name;
            partner.Rating = rating;
            partner.Description = description;
            partner.Levels = new List<decimal>();
            partner.Discounts = new List<Discount>();

            partner.Filials = new List<Filial>();
            FilialService.Create(partner, address, phoneNumber);

            partner.News = new List<News>();
            partner.Reviews = new List<Review>();
            partner.DateOfRegistration = DateTime.Now;

            _partnerRepository.Add(partner);
        }
    }

}
