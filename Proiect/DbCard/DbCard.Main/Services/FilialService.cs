//using System;
//using Proiect.Models;

//namespace Proiect.Services
//{
//    class FilialService
//    {
//        public static void Create(Partner partner, string address, string phoneNumber)
//        {
//            var filial = new Filial();

//            filial.PartnerId = partner.Id;
//            filial.Id = Guid.NewGuid();
//            filial.Address = address;
//            filial.PhoneNumber = phoneNumber;

//            partner.Filials.Add(filial);
//        }
//    }
//}
