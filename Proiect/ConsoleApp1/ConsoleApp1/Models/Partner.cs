using System;
using System.Collections.Generic;
using Proiect.Services;

namespace Proiect.Models
{
    public class Partner : User, ISubject
    {
        public string Logo { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public List<decimal> Levels { get; set; }
        public List<Discount> Discounts { get; set; }
        public List<Filial> Filials { get; set; }
        public List<News> News { get; set; }
        public List<Review> Reviews { get; set; }

        private List<IObserver> _observers = new List<IObserver>();

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