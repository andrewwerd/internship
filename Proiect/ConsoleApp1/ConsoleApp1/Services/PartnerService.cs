using System;
using System.Linq;
using Proiect.Models;
using Proiect.Repository;

namespace Proiect.Services
{
    class PartnerService : IPartnerService
    {
        public void GetDiscount(CurrentDiscount discount)
        {
            var partner = Repository<Partner>.Instance.GetById(discount.Discount.PartnerId);
            var level = partner.Levels.FindLastIndex(x => x < discount.Balance);
            discount.Discount = partner.Discounts[level];
        }
        public static Notification FreshNews(Partner partner)
        {
            var notification = new Notification();
            var news = partner.News.Last();
            notification.Author = partner.Name;
            notification.DateTime = news.Date;
            notification.Text = news.ShortDescription;
            notification.Title = news.Title;
            return notification;
        }
    }
}