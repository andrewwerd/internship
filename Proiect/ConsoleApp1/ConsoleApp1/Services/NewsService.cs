using System;
using Proiect.Models;

namespace Proiect.Services
{
    class NewsService
    {
        public static News Create(Partner partner, string title, string body, string image = "")
        {

            var news = new News();

            news.Id = Guid.NewGuid();
            news.PartnerId = partner.Id;
            news.Text = body;
            news.Title = title;
            news.Image = image;
            news.Date = DateTime.Now;

            return news;

        }
    }
}
