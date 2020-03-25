//using System;
//using Proiect.Models;
//using System.Linq;
//using System.Collections.Generic;
//using System.Text;

//namespace Proiect.Services
//{
//    class NewsFactory
//    {
//        public static void CreateSimple(Partner partner, string title, string body, string image = "")
//        {

//            var news = new News();

//            news.Id = Guid.NewGuid();
//            news.PartnerId = partner.Id;
//            news.Text = body;
//            news.ShortDescription = body.Take(80).ToString()+"...";
//            news.Title = title;
//            news.Image = image;
//            news.Date = DateTime.Now;

//            partner.News.Add(news);

//        }
//        public static void CreateWithNotification(Partner partner, string title, string shortDiscription, string body, string image = "")
//        {

//            var news = new News();

//            news.Id = Guid.NewGuid();
//            news.PartnerId = partner.Id;
//            news.Text = body;
//            news.ShortDescription = shortDiscription;
//            news.Title = title;
//            news.Image = image;
//            news.Date = DateTime.Now;

//            partner.News.Add(news);

//        }
//    }
//}
