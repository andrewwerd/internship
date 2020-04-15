using dbCard.Context;
using dbCard.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dbCard.Main
{
    public static class DatabaseInitialization
    {
        public static void UserInitialization(this dbCardContext context)
        {
            context.Set<User>().Add(new User() { UserName = "Bandirdin", Password = "*******", Email = "bandirdi@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Tygratius", Password = "*******", Email = "tygratius@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Keghma", Password = "*******", Email = "keghma@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Gavizar", Password = "*******", Email = "gavizar@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Adoghma", Password = "*******", Email = "rinar@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Grinara", Password = "*******", Email = "Grinara@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Sabandis", Password = "*******", Email = "sabandis@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Graninaya", Password = "*******", Email = "graninaya@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Saithiginn", Password = "*******", Email = "saithiginn@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Oghmath", Password = "*******", Email = "oghmath@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Nargas", Password = "*******", Email = "nargas@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Buzarim", Password = "*******", Email = "buzarim@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Kulahelm", Password = "*******", Email = "kulahelm@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Morasida", Password = "*******", Email = "morasida@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Felhagamand", Password = "*******", Email = "felhagamand@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Moath", Password = "*******", Email = "moath@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Adrierim", Password = "*******", Email = "adrierim@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Kiririm", Password = "*******", Email = "kiririm@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Anayazar", Password = "*******", Email = "anayazar@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Gavinratus", Password = "*******", Email = "gavinratus@gmail.com" });
            context.Set<User>().Add(new User() { UserName = "Androrad", Password = "*******", Email = "androrad@gmail.com" });
        }
        public static void CustomerInitialization(this dbCardContext context)
        {
            context.Set<Customer>().Add(new Customer { FirstName = "Adonis", LastName = "Allen", DateOfBirth = DateTime.Parse("04.08.1998"), Gender = "Male", UserId = context.Set<User>().ToList()[0].Id });
            context.Set<Customer>().Add(new Customer { FirstName = "Samuel", LastName = "Patterson", DateOfBirth = DateTime.Parse("12.11.1978"), Gender = "Male", UserId = context.Set<User>().ToList()[1].Id });
            context.Set<Customer>().Add(new Customer { FirstName = "Varun", LastName = "Hall", DateOfBirth = DateTime.Parse("09.05.1951"), Gender = "Female", UserId = context.Set<User>().ToList()[2].Id });
            context.Set<Customer>().Add(new Customer { FirstName = "Tristian", LastName = "Griffin", DateOfBirth = DateTime.Parse("19.07.1991"), Gender = "Male", UserId = context.Set<User>().ToList()[3].Id });
            context.Set<Customer>().Add(new Customer { FirstName = "Vann", LastName = "Rivera", DateOfBirth = DateTime.Parse("23.02.1961"), Gender = "Female", UserId = context.Set<User>().ToList()[4].Id });
            context.Set<Customer>().Add(new Customer { FirstName = "Nile", LastName = "Ward", DateOfBirth = DateTime.Parse("29.06.1986"), Gender = "Female", UserId = context.Set<User>().ToList()[5].Id });
            context.Set<Customer>().Add(new Customer { FirstName = "John", LastName = "Sanchez", DateOfBirth = DateTime.Parse("20.09.1987"), Gender = "Male", UserId = context.Set<User>().ToList()[6].Id });
            context.Set<Customer>().Add(new Customer { FirstName = "Austin", LastName = "Green", DateOfBirth = DateTime.Parse("09.03.1982"), Gender = "Male", UserId = context.Set<User>().ToList()[7].Id });
            context.Set<Customer>().Add(new Customer { FirstName = "Venus", LastName = "Phillips", DateOfBirth = DateTime.Parse("15.10.1996"), Gender = "Female", UserId = context.Set<User>().ToList()[8].Id });
            context.Set<Customer>().Add(new Customer { FirstName = "Douglas", LastName = "Perry", DateOfBirth = DateTime.Parse("18.02.1975"), Gender = "Male", UserId = context.Set<User>().ToList()[9].Id });
            context.Set<Customer>().Add(new Customer { FirstName = "Urbane", LastName = "Cooper", DateOfBirth = DateTime.Parse("16.05.1973"), Gender = "Male", UserId = context.Set<User>().ToList()[10].Id });
            context.Set<Customer>().Add(new Customer { FirstName = "Drake", LastName = "Cook", DateOfBirth = DateTime.Parse("25.11.1968"), Gender = "Male", UserId = context.Set<User>().ToList()[11].Id });
        }
        public static void PartnerInitialization(this dbCardContext context)
        {
            context.Set<Partner>().Add(new Partner { Name = "Dica", Category = "BookShop", Description = "", BirthdayDiscount = 0, UserId = context.Set<User>().ToList()[13].Id });
            context.Set<Partner>().Add(new Partner { Name = "Imay", Category = "FoodShop", Description = "", BirthdayDiscount = 0, UserId = context.Set<User>().ToList()[14].Id });
            context.Set<Partner>().Add(new Partner { Name = "Mexxo", Category = "FoodShop", Description = "", BirthdayDiscount = 0, UserId = context.Set<User>().ToList()[15].Id });
            context.Set<Partner>().Add(new Partner { Name = "Pexxov", Category = "Restaurant", Description = "", BirthdayDiscount = 0, UserId = context.Set<User>().ToList()[16].Id });
            context.Set<Partner>().Add(new Partner { Name = "Awarich", Category = "BarberShop", Description = "", BirthdayDiscount = 0, UserId = context.Set<User>().ToList()[17].Id });
            context.Set<Partner>().Add(new Partner { Name = "Ciirix", Category = "Restaurant", Description = "", BirthdayDiscount = 0, UserId = context.Set<User>().ToList()[18].Id });
            context.Set<Partner>().Add(new Partner { Name = "Cametel", Category = "BookShop", Description = "", BirthdayDiscount = 0, UserId = context.Set<User>().ToList()[19].Id });
            context.Set<Partner>().Add(new Partner { Name = "Susria", Category = "DeviceShop", Description = "", BirthdayDiscount = 0, UserId = context.Set<User>().ToList()[20].Id });
        }
        public static void FilialInitialization(this dbCardContext context)
        {
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, IsMainOffice = true, Address = new Address { Country = "Moldova", Street = "Burebista", City = "Chisinau", HouseNumber = "3", Region = "Chisinau" }, PhoneNumber = "068955458",PartnerId = context.Set<Partner>().ToList()[0].Id});
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, Address = new Address { Country = "Moldova", Street = "Testimitanu", City = "Chisinau", HouseNumber = "3", Region = "Chisinau" }, PhoneNumber = "068135027", PartnerId = context.Set<Partner>().ToList()[0].Id });
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, Address = new Address { Country = "Moldova", Street = "Mesteru Manole", City = "Chisinau", HouseNumber = "4", Region = "Chisinau" }, PhoneNumber = "068738968", PartnerId = context.Set<Partner>().ToList()[1].Id, IsMainOffice = true});
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, Address = new Address { Country = "Moldova", Street = "Scuterniceni", City = "Ungheni", HouseNumber = "5", Region = "Ungheni" }, PhoneNumber = "068042320", PartnerId = context.Set<Partner>().ToList()[2].Id, IsMainOffice = true });
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, Address = new Address { Country = "Moldova", Street = "Mihai Eminescu", City = "Ungheni", HouseNumber = "6", Region = "Ungheni" }, PhoneNumber = "068782917" ,PartnerId = context.Set<Partner>().ToList()[2].Id});
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, Address = new Address { Country = "Moldova", Street = "Stefan Cel Mare", City = "Ungheni", HouseNumber = "7", Region = "Ungheni" }, PhoneNumber = "068814218", PartnerId = context.Set<Partner>().ToList()[3].Id, IsMainOffice = true });
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, Address = new Address { Country = "Moldova", Street = "Nationala", City = "Balti", HouseNumber = "87", Region = "Balti" }, PhoneNumber = "079488366", PartnerId = context.Set<Partner>().ToList()[4].Id, IsMainOffice = true });
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, Address = new Address { Country = "Moldova", Street = "Dacia", City = "Chisinau", HouseNumber = "45", Region = "Chisinau" }, PhoneNumber = "079880065", PartnerId = context.Set<Partner>().ToList()[7].Id, IsMainOffice = true });
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, Address = new Address { Country = "Moldova", Street = "Alexadru Ioan Cuza", City = "Chisinau", HouseNumber = "12", Region = "Chisinau" }, PhoneNumber = "079307066", PartnerId = context.Set<Partner>().ToList()[5].Id, IsMainOffice = true });
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, Address = new Address { Country = "Moldova", Street = "Decebal", City = "Chisinau", HouseNumber = "23", Region = "Chisinau" }, PhoneNumber = "079683072", PartnerId = context.Set<Partner>().ToList()[4].Id });
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, Address = new Address { Country = "Moldova", Street = "Feroviara", City = "Balti", HouseNumber = "98", Region = "Balti" }, PhoneNumber = "079586109", PartnerId = context.Set<Partner>().ToList()[2].Id });
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, Address = new Address { Country = "Moldova", Street = "Boico", City = "Ungheni", HouseNumber = "23", Region = "Ungheni" }, PhoneNumber = "079386166", PartnerId = context.Set<Partner>().ToList()[6].Id, IsMainOffice = true });
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, Address = new Address { Country = "Moldova", Street = "Ungureanu", City = "Chisinau", HouseNumber = "12", Region = "Chisinau" }, PhoneNumber = "079225632", PartnerId = context.Set<Partner>().ToList()[2].Id });
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, Address = new Address { Country = "Moldova", Street = "Bernardarzi", City = "Balti", HouseNumber = "22", Region = "Balti" }, PhoneNumber = "079984571", PartnerId = context.Set<Partner>().ToList()[1].Id });
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, Address = new Address { Country = "Moldova", Street = "Tudor Strisca", City = "Chisinau", HouseNumber = "60", Region = "Chisinau" }, PhoneNumber = "079619905", PartnerId = context.Set<Partner>().ToList()[7].Id });
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, Address = new Address { Country = "Moldova", Street = "Valea Crucei", City = "Chisinau", HouseNumber = "34/3", Region = "Chisinau" }, PhoneNumber = "079705389", PartnerId = context.Set<Partner>().ToList()[5].Id, IsMainOffice = true });
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, Address = new Address { Country = "Moldova", Street = "Burebista", City = "Balti", HouseNumber = "12", Region = "Balti" }, PhoneNumber = "067867381", PartnerId = context.Set<Partner>().ToList()[3].Id });
            context.Set<Filial>().Add(new Filial {Schedule = new Schedule{Monday = "08:00-17:00", Tuesday="08:00-17:00", Wednesday = "08:00-17:00", Thursday = "08:00-17:00", Friday = "08:00-17:00"}, Address = new Address { Country = "Moldova", Street = "Burebista", City = "Balti", HouseNumber = "7", Region = "Balti" }, PhoneNumber = "067972032", PartnerId = context.Set<Partner>().ToList()[4].Id });


        }
    }
}