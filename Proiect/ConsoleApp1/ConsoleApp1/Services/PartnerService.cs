using System;
using Proiect.Models;
using Proiect.Repository;

namespace Proiect.Services
{
    internal class PartnerService : IPartnerService: ISubject
    {
        public void GetDiscount(CurrentDiscount discount)
        {
            var partner = Repository<Partner>.Instance.GetById(discount.Discount.PartnerId);
            var level = partner.Levels.FindLastIndex(x => x < discount.Balance);
            discount.Discount = partner.Discounts[level];
        }

        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }
        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);        
        }
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }

}
