using DbCard.Context;
using DbCard.Domain;
using DbCard.Domain.Auth;
using DbCard.Services;
using DbCard.Infrastructure.Extensions;
using DbCard.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DbCard.Infrastructure
{
    public class Seed
    {

        public static async Task SeedPartners(DbCardContext context)
        {
            if (!context.Partners.Any())
            {
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedUsers(UserManager<User> userManager, ICustomerService customerService)
        {
            if (!userManager.Users.Any())
            {
                var user = new User()
                {
                    UserName = "john11",
                    Email = "john1@dbcard.com"
                };
                await userManager.CreateAsync(user, "Qwerty12345");
                await userManager.AddToRoleAsync(user, "Customer");
                var customer = new Customer()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Barcode = Guid.NewGuid().NewShortGuid()
                };
                await customerService.CreateAsync(customer, user);
            }
        }
        public static async Task SeedCategories(DbCardContext context)
        {
            if (!context.Categories.Any())
            {
                var cat1 = new Category()
                {
                    Name = "Развлечение",
                    Subcategories = new List<Subcategory>()
                    {
                        new Subcategory(){
                            Name = "Кинотеатры"
                        },
                        new Subcategory(){
                            Name = "Театры"
                        },
                        new Subcategory(){
                            Name = "Командные игры"
                        },
                        new Subcategory(){
                            Name = "Развлекательные центр"
                        },
                        new Subcategory(){
                            Name = "Прочее"
                        }
                    }
                };
                var cat2 = new Category()
                {
                    Name = "Образование",
                    Subcategories = new List<Subcategory>()
                    {
                        new Subcategory(){
                            Name = "Языки"
                        },
                        new Subcategory(){
                            Name = "Программирование"
                        },
                        new Subcategory(){
                            Name = "Науки"
                        },
                        new Subcategory(){
                            Name = "Библиотеки"
                        },
                        new Subcategory(){
                            Name = "Тренинги"
                        },
                        new Subcategory(){
                            Name = "Прочее"
                        }
                    }
                };
                var cat3 = new Category()
                {
                    Name = "Спорт",
                    Subcategories = new List<Subcategory>()
                    {
                        new Subcategory(){
                            Name = "Фитнес клуб"
                        },
                        new Subcategory(){
                            Name = "Бассейн"
                        },
                        new Subcategory(){
                            Name = "Спорт зал"
                        },
                        new Subcategory(){
                            Name = "Прочее"
                        }
                    }
                };
                var cat4 = new Category()
                {
                    Name = "Шопинг",
                    Subcategories = new List<Subcategory>()
                    {
                        new Subcategory(){
                            Name = "Одежда"
                        },
                        new Subcategory(){
                            Name = "Белье"
                        },
                        new Subcategory(){
                            Name = "Обувь"
                        },
                        new Subcategory(){
                            Name = "Цветы"
                        },
                        new Subcategory(){
                            Name = "Книги"
                        },
                        new Subcategory(){
                            Name = "Спорт"
                        },
                        new Subcategory(){
                            Name = "Творчество"
                        },
                        new Subcategory(){
                            Name = "Электроника"
                        },
                        new Subcategory(){
                            Name = "Прочее"
                        }
                    }
                };
                var cat5 = new Category()
                {
                    Name = "Здоровье",
                    Subcategories = new List<Subcategory>()
                    {
                        new Subcategory(){
                            Name = "Аптека"
                        },
                        new Subcategory(){
                            Name = "Диагностика"
                        },
                        new Subcategory(){
                            Name = "Стоматология"
                        },
                        new Subcategory(){
                            Name = "Прочее"
                        }
                    }
                };
                var cat6 = new Category()
                {
                    Name = "Красота",
                    Subcategories = new List<Subcategory>()
                    {
                        new Subcategory(){
                            Name = "Парикмахерские"
                        },
                        new Subcategory(){
                            Name = "Салон красоты"
                        },
                        new Subcategory(){
                            Name = "Спа"
                        },
                        new Subcategory(){
                            Name = "Прочее"
                        }
                    }
                };
                var cat7 = new Category()
                {
                    Name = "Питание",
                    Subcategories = new List<Subcategory>()
                    {
                        new Subcategory(){
                            Name = "Рестораны"
                        },
                        new Subcategory(){
                            Name = "Кафе"
                        },
                        new Subcategory(){
                            Name = "Продуктовый магазин"
                        },
                        new Subcategory(){
                            Name = "Прочее"
                        }
                    }
                };
                var cat8 = new Category()
                {
                    Name = "Для дома",
                    Subcategories = new List<Subcategory>()
                    {
                        new Subcategory(){
                            Name = "Мебель"
                        },
                        new Subcategory(){
                            Name = "Стройтельный"
                        },
                        new Subcategory(){
                            Name = "Бытовая химия"
                        },
                        new Subcategory(){
                            Name = "Прочее"
                        }
                    }
                };
                var cat9 = new Category()
                {
                    Name = "Услуги",
                    Subcategories = new List<Subcategory>()
                    {
                        new Subcategory(){
                            Name = "Фотография"
                        },
                        new Subcategory(){
                            Name = "Уборка"
                        },
                        new Subcategory(){
                            Name = "Строительные"
                        },
                        new Subcategory(){
                            Name = "Аниматоры"
                        },
                        new Subcategory(){
                            Name = "Прочее"
                        }
                    }
                };
                var cat10 = new Category()
                {
                    Name = "Туризм",
                    Subcategories = new List<Subcategory>()
                    {
                        new Subcategory(){
                            Name = "Внутри страны"
                        },
                        new Subcategory(){
                            Name = "За границей"
                        },
                        new Subcategory(){
                            Name = "Прочее"
                        }
                    }
                };

                context.Categories.Add(cat1);
                context.Categories.Add(cat2);
                context.Categories.Add(cat3);
                context.Categories.Add(cat4);
                context.Categories.Add(cat5);
                context.Categories.Add(cat6);
                context.Categories.Add(cat7);
                context.Categories.Add(cat8);
                context.Categories.Add(cat9);
                context.Categories.Add(cat10);

                await context.SaveChangesAsync();
            }
        }
        public static async Task SeedRoles(RoleManager<Role> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new Role() { Name = "Admin" });
                await roleManager.CreateAsync(new Role() { Name = "Customer" });
                await roleManager.CreateAsync(new Role() { Name = "Partner" });
            }
        }
    }
}

