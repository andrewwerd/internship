using System;
using System.Data.SqlClient;
using System.Linq;
using dbCard.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace dbCard.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            dbCardContextSettings.Create();
            using (var db = new dbCardContext())
            {
                db.UserInitialization();
                db.SaveChanges();
                db.CustomerInitialization();
                db.SaveChanges();
                db.PartnerInitialization();
                db.SaveChanges();
                db.FilialInitialization();
                db.SaveChanges();
            }

            //    dbCardContextSettings.Create();
            //using (var db = new dbCardContext())
            //{
            //    var PartnersWithFilials = db.Filials
            //        .Select(x => new { PartnerName = x.Partner.Name, FilialAddress = x.Address })
            //        .GroupBy(x => new { x.PartnerName, x.FilialAddress.Region, x.FilialAddress.City })
            //        .Select(x => new { x.Key.PartnerName, x.Key.City, FilialsCount = x.Count() })
            //        .Where(x => x.FilialsCount > 0)
            //        .OrderBy(x => x.City)
            //        .ThenBy(x => x.PartnerName);
            //    foreach (var i in PartnersWithFilials)
            //        Console.WriteLine($"In {i.City} is {i.FilialsCount} fililas of {i.PartnerName} ");
            //}
            //    WriteSmth();
            //    using (var db = new dbCardContext())
            //    {
            //        var Addresses = db.Addresses;
            //        var FilialsWithAddresses = db.Filials.ToList()
            //            .GroupJoin(Addresses,
            //                        x => x.Id,
            //                        x => x.FilialId,
            //                        (Filial, Address) => new { Name = Filial.Partner.Name, PhoneNumber = Filial.PhoneNumber, Address = Address.First() })
            //            .OrderBy(x => x.Name);
            //        foreach (var item in FilialsWithAddresses)
            //        {
            //            Console.WriteLine($"{item.Name}, {item.Address}, {item.PhoneNumber}");
            //        }
            //    }
            //    WriteSmth();
            //    using(var db = new dbCardContext())
            //    {
            //        var partners = db.Partners.Where(x=>x.Filials.Any());
            //        Console.WriteLine("Partners with filials");
            //        foreach (var item in partners)
            //        {
            //            Console.WriteLine($"{item.Name}");
            //        }
            //        Console.WriteLine("Partners without filials");
            //        var partners1 = db.Partners.Where(x => !x.Filials.Any());
            //        foreach (var item in partners1)
            //        {
            //            Console.WriteLine($"{item.Name}");
            //        }
            //    }
            //    WriteSmth();
            //    using (var db = new dbCardContext())
            //    {
            //        var partners = db.Partners
            //            .Select(x => new { x.Name, IsWeb = (x.Filials.Count() > 1) ? true : false })
            //            .Where(x => x.IsWeb);
            //        Console.WriteLine("Partners");
            //        foreach (var item in partners)
            //        {
            //            Console.WriteLine($"Partner {item.Name}, is {((item.IsWeb)?"":"not ")}a web  ");
            //        }
            //    }
            //}
        }
        public static void WriteSmth()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("=============================================");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}