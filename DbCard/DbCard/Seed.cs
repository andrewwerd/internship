using DbCard.Context;
using DbCard.Domain;
using DbCard.Domain.Auth;
using DbCard.Infrastructure.Extensions;
using DbCard.Services;
using DbCard.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure
{
    public class Seed
    {

        public static async Task SeedPartners(UserManager<User> userManager, DbCardContext context, IPartnerService partnerService)
        {
            if (!context.Partners.Any())
            {
                var user1 = new User()
                {
                    UserName = "partner1",
                    Email = "partner1@dbcard.com"
                };
                await userManager.CreateAsync(user1, "Qwerty12345");
                await userManager.AddToRoleAsync(user1, "Partner");
                var Nomer1 = new Partner()
                {
                    Name = "N1",
                    PremiumDiscounts = new List<PremiumDiscount>()
                    {
                        new PremiumDiscount()
                        {
                            DiscountPercent = (decimal)1.5,
                            AccumulatingPercent = (decimal)0.5,
                            PriceOfDiscount = 500,
                        },
                        new PremiumDiscount()
                        {
                            DiscountPercent = (decimal)2,
                            AccumulatingPercent = (decimal)0.5,
                            PriceOfDiscount = 5000,
                        },
                        new PremiumDiscount()
                        {
                            DiscountPercent = 2,
                            AccumulatingPercent = 1,
                            PriceOfDiscount = 7000,
                        }
                    },
                    StandartDiscounts = new List<StandartDiscount>()
                    {
                        new StandartDiscount()
                        {
                            DiscountPercent = (decimal)1.5,
                            AmountOfDiscount = 500,
                        },
                        new StandartDiscount()
                        {
                            DiscountPercent = 2,
                            AmountOfDiscount = 1000,
                        }
                    },
                    Filials = new List<Filial>()
                    {
                        new Filial()
                        {
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Московский пр-т",
                            HouseNumber = "9/5",
                            PhoneNumber = "100000000",
                            IsMainOffice = true
                        },
                        new Filial()
                        {
                            Region = "Кишинев",
                            PhoneNumber = "100000001",
                            City = "Кишинев",
                            Street = "Дечебал",
                            HouseNumber = "139"
                        },
                        new Filial()
                        {
                            Region = "Кишинев",
                            City = "Кишинев",
                            PhoneNumber = "100000002",
                            Street = "Лев Толстой",
                            HouseNumber = "24/1"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000003",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Зелински",
                            HouseNumber = "7"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000004",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Алеку Руссо",
                            HouseNumber = "15"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000005",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "А. Щусев",
                            HouseNumber = "55"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000006",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Тестимицану",
                            HouseNumber = "23"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000007",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Дачия",
                            HouseNumber = "47/7"
                        }
                    },
                    Description = "Сеть супермаркетов Nr1 является на сегодняшний день одной из самых популярных в городе. Удобное расположение, богатый ассортимент товаров и высокий уровень обслуживания привлекают покупателей в супермаркеты день ото дня.",
                    Site = "nr1.md",
                    News = new List<News>()
                    {
                        new News()
                        {
                            DateOfCreation = DateTime.Now,
                            Title="Открытие нового магазина по адресу Московский пр-т, 9/5",
                            Body = @"Дорогие друзья! Cупермаркет «Nr1» спешит поделиться с Вами радостными новостями! 
                            Сеть ""Nr1"" открыла новый супермаркет по адресу Московский пр-т, 9/5. Это 17-й магазин сети ""Nr1"".
                            При строительстве этого магазина мы использовали современные технологии, которые экономят электричество и газ. Все освещение магазина, включая освещение холодильных витрин - энергосберегающие LED лампы. А тепло, которое вырабатывают холодильники, мы используем для отопления и подогрева воды. Благодаря такой экономии ""Nr1"" продолжает сдерживать рост цен.",
                        },
                        new News()
                        {
                            DateOfCreation = DateTime.Now,
                            Title = "Nr1 по адресу: ул. Пушкин 32, снова открыл свои двери для старых и новых друзей !",
                            Body = @"Добрый день Уважаемые клиенты сети супермаркетов Nr1!
                            Хотим Вам сообщить приятную, предновогоднюю новость:
                            Полюбившийся многим жителям Кишинёва наш магазин расположенный по адресу: ул.Пушкин 32(торговый центр: ""Sun City""), снова открыл свои двери для старых и новых друзей!
                            Приглашаем посетить наш обновленный магазин и желаем Вам приятных праздников и покупок!
                            Ваша сеть супермаркетов Nr1!"
                        },
                        new News()
                        {
                            DateOfCreation = DateTime.Now,
                            Title = "Новый продукт: Макароны «Шебекинские»",
                            Body = @"Макароны «Шебекинские» - качественная продукция, выполненная из муки пшеницы грубого помола и максимально приближенная к итальянской пасте. Широтой ассортимента и качеством макарон марка удовлетворяет все потребительные нужды.
                            Продукция создается по лучшим образцам макаронной промышленности с использованием опыта итальянских производителей, а также с применением итальянского оборудования.
                            Покупайте качественные макароны по доступным ценам в сети супермаркетов Nr1!"
                        }
                    },
                    Rating = (decimal)8.5
                };
                await partnerService.AddToCategory(Nomer1, "Питание");
                await partnerService.AddToSubcategory(Nomer1, "Продуктовый магазин");
                await partnerService.CreateAsync(Nomer1, user1);


                var user2 = new User()
                {
                    UserName = "partner2",
                    Email = "partner2@dbcard.com"
                };
                await userManager.CreateAsync(user2, "Qwerty12345");
                await userManager.AddToRoleAsync(user2, "Partner");
                var Andys = new Partner()
                {
                    Name = "Andy's",
                    PremiumDiscounts = new List<PremiumDiscount>()
                    {
                        new PremiumDiscount()
                        {
                            DiscountPercent = 1.5M,
                            AccumulatingPercent = 0.5M,
                            PriceOfDiscount = 1000,
                        },
                        new PremiumDiscount()
                        {
                            DiscountPercent = 2M,
                            AccumulatingPercent = 1M,
                            PriceOfDiscount = 2500,
                        },
                        new PremiumDiscount()
                        {
                            DiscountPercent = 2M,
                            AccumulatingPercent = 2M,
                            PriceOfDiscount = 5000,
                        }
                    },
                    StandartDiscounts = new List<StandartDiscount>()
                    {
                        new StandartDiscount()
                        {
                            DiscountPercent = 1.5M,
                            AmountOfDiscount = 500,
                        },
                        new StandartDiscount()
                        {
                            DiscountPercent = 2M,
                            AmountOfDiscount = 750,
                        }
                    },
                    Filials = new List<Filial>()
                    {
                        new Filial()
                        {
                            PhoneNumber = "100010002",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Куза Водэ",
                            HouseNumber = "49/1",
                            IsMainOffice = true
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000008",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Алба Юлия,",
                            HouseNumber = "23/4"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000009",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Дачия",
                            HouseNumber = "44"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000010",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Каля Иешилор",
                            HouseNumber = "10"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000011",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Ион Крянгэ",
                            HouseNumber = " 78"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000012",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Московский проспект",
                            HouseNumber = "6"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000013",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Штефан чел Маре",
                            HouseNumber = "202"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000014",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = " Штефан чел Маре",
                            HouseNumber = "152"
                        }
                    },
                    Description = "Andy's Lifestyle - это то: как мы изо дня в день восхищаем наших гостей обслуживанием; как на глазах наши бармены и официанты превращаются в директоров, а повара постигают все новые вершины кулинарного мастерства. За 20 лет стиль ресторанов Andy's стал узнаваем, а вкус и качество блюд радует детей и их родителей. Стиль Andys's это когда мы вместе встречаемся и отмечаем дни рождения, крестины и другие памятные даты вместе. Стиль Andy's это уже более 50 рестаранов по всей Молдове и за её пределами.",
                    Site = "www.andys.md",
                    News = new List<News>()
                    {
                        new News()
                        {
                            DateOfCreation = DateTime.Now,
                            Title="Долгожданное открытие!",
                            Body = @"Друзья, мы знаем, что вы скучали по ресторану на ул. Пушкина, 32. Мы закрывали его для обновления и вот теперь все готово для новой встречи с любимыми посетителями! Долгожданное открытие уже состоялось - 1 марта!"},
                        new News()
                        {
                            DateOfCreation = DateTime.Now,
                            Title = "Встречаем Великий пост",
                            Body = @"Во время Великого поста все готовятся к празднованию Пасхи, и мы рады поддержать вас в этот важный период. Со 2 марта в ресторанах Andy’s стартует специальное меню, в котором каждое блюдо — постное."
                        },
                        new News()
                        {
                            DateOfCreation = DateTime.Now,
                            Title = "Завтраки — на любое настроение",
                            Body = @"С 15 ноября в меню наших ресторанов появятся новые завтраки. Сытный английский и легкий французский. А еще — вкуснейшие круассаны с яйцом, беконом и сыром и многое другое. Мы не знаем, как сложится ваш день, но уверены — завтрак в Andy’s пройдет идеально."
                        }
                    },
                    Rating = 8.65M
                };
                await partnerService.AddToCategory(Andys, "Питание");
                await partnerService.AddToSubcategory(Andys, "Рестораны");
                await partnerService.CreateAsync(Andys, user2);


                var user3 = new User()
                {
                    UserName = "partner3",
                    Email = "partner3@dbcard.com"
                };
                await userManager.CreateAsync(user3, "Qwerty12345");
                await userManager.AddToRoleAsync(user3, "Partner");
                var Darwin = new Partner()
                {
                    Name = "Darwin",
                    PremiumDiscounts = new List<PremiumDiscount>()
                    {
                        new PremiumDiscount()
                        {
                            DiscountPercent = 2M,
                            AccumulatingPercent = 1M,
                            PriceOfDiscount = 5000,
                        },
                        new PremiumDiscount()
                        {
                            DiscountPercent = 3M,
                            AccumulatingPercent = 2M,
                            PriceOfDiscount = 10000,
                        },
                        new PremiumDiscount()
                        {
                            DiscountPercent = 5M,
                            AccumulatingPercent = 2M,
                            PriceOfDiscount = 20000,
                        }
                    },
                    StandartDiscounts = new List<StandartDiscount>()
                    {
                        new StandartDiscount()
                        {
                            DiscountPercent = 1.5M,
                            AmountOfDiscount = 1000,
                        },
                        new StandartDiscount()
                        {
                            DiscountPercent = 3M,
                            AmountOfDiscount = 3000,
                        }
                    },
                    Filials = new List<Filial>()
                    {
                        new Filial()
                        {
                            PhoneNumber = "100000020",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = " Арборилор",
                            HouseNumber = "21б"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000021",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Дачия",
                            HouseNumber = "23"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000122",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Индепенденцей",
                            HouseNumber = "13"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000022",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Хынчешть",
                            HouseNumber = "60/4"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000023",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Штефан чел Маре",
                            HouseNumber = "132"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000024",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Штефан чел Маре",
                            HouseNumber = "71"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000025",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Мирча чел Бэтрын",
                            HouseNumber = "3"
                        },
                        new Filial()
                        {
                            PhoneNumber = "100000026",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Каля Ешилор",
                            HouseNumber = "3/1"
                        }
                    },
                    Description = @"Darwin - самый амбициозный ритейлер гаджетов и смартфонов
                    Да, мы продаем смартфоны, ноутбуки, планшеты и множество гаджетов.Но помимо этого мы меняем мир вокруг нас.Мы организуем красочные мероприятия,
                    такие как фестиваль цветов Дарвин и полезные программы, как Darwin лаборатория. Мы являемся авторизованными дилерами Apple, Samsung, Fly, Philips, Nokia, Acer, Lenovo, Dell, Asus, Intel, JBL, Beats by Dr.Dre, Skullcandy и других.Мы начали работу в марте 2013 года в Республике Молдова, чтобы украсить ваш цифровой опыт эмоциями, стилем и креативностью.",
                    Site = "darwin.md",
                    News = new List<News>()
                    {
                        new News()
                        {
                            DateOfCreation = DateTime.Now,
                            Title="iPhone 12: все, что нужно знать о «укушенном яблоке» 2020 года",
                            Body = @"В последнее время было много слухов о выпуске последней модели iPhone и ее новых спецификаций. Мы собрали всю информацию, и вот краткое изложение того, что Apple готовит для нас в 2020 году. Новые и основные детали относятся к усовершенствованию новой системы распознавания лиц Face ID. Также говорят о количестве новых моделей и разнице между ними, и не в последнюю очередь, о производительности устройств с обновлением ОЗУ"
                        },
                        new News()
                        {
                            DateOfCreation = DateTime.Now,
                            Title = "Насколько долговечен ваш телефон - стандарты IP",
                            Body = @"Вы определенно с нетерпением ждете побега куда угодно! Либо на горе, на море, либо у бабушки! И они должны быть сняты. Но вы уверены, что ваш телефон справится с этой задачей? Все чаще и чаще, когда запускается новый смартфон, мы слышим, как «непроницаемость» хвалят в тех или иных обстоятельствах, но ... это как если бы мы не хотели проверять на своем телефоне, каковы пределы влажности, которые он выдержит."
                        }
                    },
                    Rating = 8M
                };
                await partnerService.AddToCategory(Darwin, "Шопинг");
                await partnerService.AddToSubcategory(Darwin, "Электроника");
                await partnerService.CreateAsync(Darwin, user3);

                var user4 = new User()
                {
                    UserName = "partner4",
                    Email = "partner4@dbcard.com"
                };
                await userManager.CreateAsync(user4, "Qwerty12345");
                await userManager.AddToRoleAsync(user4, "Partner");
                var Vizaje_Nica = new Partner()
                {
                    Name = "Vizaje-Nica",
                    PremiumDiscounts = new List<PremiumDiscount>()
                    {
                        new PremiumDiscount()
                        {
                            DiscountPercent = 1.5M,
                            AccumulatingPercent = 0.5M,
                            PriceOfDiscount = 1500,
                        },
                        new PremiumDiscount()
                        {
                            DiscountPercent = 2M,
                            AccumulatingPercent = 2M,
                            PriceOfDiscount = 5000,
                        },
                        new PremiumDiscount()
                        {
                            DiscountPercent = 3M,
                            AccumulatingPercent = 3M,
                            PriceOfDiscount = 7000,
                        }
                    },
                    StandartDiscounts = new List<StandartDiscount>()
                    {
                        new StandartDiscount()
                        {
                            DiscountPercent = 2M,
                            AmountOfDiscount = 500,
                        },
                        new StandartDiscount()
                        {
                            DiscountPercent = 5M,
                            AmountOfDiscount = 1000,
                        }
                    },
                    Filials = new List<Filial>()
                    {
                        new Filial()
                        {
                            PhoneNumber = "100000027",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Штефан чел Маре",
                            HouseNumber = "136",
                            IsMainOffice = true
                        },
                        new Filial()
                        {
                            PhoneNumber="100000028",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Штефан чел Маре",
                            HouseNumber = "8"
                        },
                        new Filial()
                        {
                            PhoneNumber="100000029",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Пушкина",
                            HouseNumber = "32"
                        },
                        new Filial()
                        {
                            PhoneNumber="100000030",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Киевская",
                            HouseNumber = "16/1"
                        },
                        new Filial()
                        {
                            PhoneNumber="100000031",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Алеку Руссо",
                            HouseNumber = "28"
                        },
                        new Filial()
                        {
                            PhoneNumber="100000032",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Дечебал",
                            HouseNumber = "23"
                        },
                    },
                    Description = @"Сеть магазинов ""Vizaje-Nica"" - торговая сеть магазинов парфюмерии и косметики #1 в Молдове. С 1990 года мы являемся официальным представителем и импортером крупнейших мировых марок на территории Молдовы. Наша компания располагает сетью специализированных магазинов, расположенных в самых посещаемых торговых центрах столицы, в Бельцах и Унгенах.",
                    Site = "vizaje-nica.com",
                    News = new List<News>()
                    {
                        new News()
                        {
                            DateOfCreation = DateTime.Now,
                            Title="8 March Happy Womens Day Offer!",
                            Body = @"Vizaje-Nica приготовила для наших милых Дам что-то особенное! Мега Акция на Парфюмерию и Уход! На всю парфюмерию:
                                    Скидка 20% — при покупке одного парфюма
                                    Скидка 25% — при покупке 2х парфюмов
                                    Скидка 30% — при покупке 3х парфюмов
                                    В акции не участвуют Antonio Banderas, Jeanne Arthes, Color of Benetton, Franck Olivier"},
                        new News()
                        {
                            DateOfCreation = DateTime.Now,
                            Title = "Мужской День в VIZAJE-NICA!",
                            Body = @"При покупке 2х любых единиц мужского ассортимента получаете в ПОДАРОК:
                                   Гель для бритья от Cottage 50 мл или Мужской дезодорант от Cottage 30 мл или Гель для душа от Mercedes-Benz 75 мл.
                                   При покупке от 1000 лей получаете ПОДАРОК:
                                   Thierry Mugler A Men Шампунь или Azzaro Wanted Шампунь 50 мл или Hugo Boss Гель для душа 50 мл
                                   При покупке от 2000 лей получаете ПОДАРОК:
                                   Мужская косметичка Paco Rabanne или
                                   Мужская косметичка Biotherm или
                                   Мужская косметичка Thierry Mugler или
                                   Мужская косметичка Arnaud Paris
                                   При покупке от 3000 лей получаете ПОДАРОК:
                                   Power Bank от Azzaro
                                   При покупке от 4000 лей:
                                   Большая мужская сумка от Azzaro или
                                   Большая мужская сумка от Mercedes-Benz"
                        }
                    },
                    Rating = 9.5M
                };
                await partnerService.AddToCategory(Vizaje_Nica, "Шопинг");
                await partnerService.AddToSubcategory(Vizaje_Nica, "Косметика");
                await partnerService.CreateAsync(Vizaje_Nica, user4);

                var user5 = new User()
                {
                    UserName = "partner5",
                    Email = "partner5@dbcard.com"
                };
                await userManager.CreateAsync(user5, "Qwerty12345");
                await userManager.AddToRoleAsync(user5, "Partner");
                var Patria = new Partner()
                {
                    Name = "Patria",
                    PremiumDiscounts = new List<PremiumDiscount>()
                    {
                        new PremiumDiscount()
                        {
                            DiscountPercent = 3M,
                            AccumulatingPercent = 1M,
                            PriceOfDiscount = 2500,
                        },
                        new PremiumDiscount()
                        {
                            DiscountPercent = 5M,
                            AccumulatingPercent = 2M,
                            PriceOfDiscount = 5000,
                        },
                        new PremiumDiscount()
                        {
                            DiscountPercent = 8M,
                            AccumulatingPercent = 1M,
                            PriceOfDiscount = 7000,
                        }
                    },
                    StandartDiscounts = new List<StandartDiscount>()
                    {
                        new StandartDiscount()
                        {
                            DiscountPercent = 1.5M,
                            AmountOfDiscount = 500,
                        },
                        new StandartDiscount()
                        {
                            DiscountPercent = 2M,
                            AmountOfDiscount = 800,
                        }
                    },
                    Filials = new List<Filial>()
                    {
                        new Filial()
                        {
                            PhoneNumber="100000040",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Арборилор",
                            HouseNumber = "21"
                        }
                    },
                    Description = "Сеть кинотеатров",
                    Site = "patria.md",
                    News = new List<News>()
                    {
                        new News()
                        {
                            DateOfCreation = DateTime.Now,
                            Title="Привет любителям попкорна и кино! Приглашаем вас ознакомиться с премьерами этой недели, показ которых мы начнем в Четверг, 12.03.2020",
                            Body = @"Корпорация RST возвращает к жизни недавно убитого солдата Рэя Гаррисона. Армия нанороботов в его крови превратила Рэя в бессмертного Бладшота, наделенного сверхчеловеческой силой и способностью мгновенно самоисцеляться. Контролируя тело Рэя, компания влияет на его разум и воспоминания. Но герой пойдет на все, чтобы выяснить правду."},
                    },
                    Rating = 4.5M
                };
                await partnerService.AddToCategory(Patria, "Развлечение");
                await partnerService.AddToSubcategory(Patria, "Кинотеатры");
                await partnerService.CreateAsync(Patria, user5);

                var user6 = new User()
                {
                    UserName = "partner6",
                    Email = "partner6@dbcard.com"
                };
                await userManager.CreateAsync(user6, "Qwerty12345");
                await userManager.AddToRoleAsync(user6, "Partner");
                var FeniceRecords = new Partner()
                {
                    Name = "Fenice Records",
                    PremiumDiscounts = new List<PremiumDiscount>()
                    {
                        new PremiumDiscount()
                        {
                            DiscountPercent = 5M,
                            AccumulatingPercent = 0M,
                            PriceOfDiscount = 2500,
                        }
                    },
                    StandartDiscounts = new List<StandartDiscount>()
                    {
                        new StandartDiscount()
                        {
                            DiscountPercent = 1.5M,
                            AmountOfDiscount = 1000,
                        }
                    },
                    Filials = new List<Filial>()
                    {
                        new Filial()
                        {
                            PhoneNumber="100000042",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Мирча чел Бэтрын",
                            HouseNumber = "23"
                        },
                    },
                    Description = @"Уроки игры на гитаре или фортепиано от Fenice Records предназначены для всех меломанов и тех, кто хочет научиться петь на этих мелодичных инструментах, независимо от возраста. Удивите своих друзей новыми навыками после изучения этих инструментов. Во время занятий вы узнаете классические, народные, рок или современные песни в зависимости от ваших предпочтений. Не бойтесь идти на такой курс,даже если вы никогда не держали в руках гитару.Вы будете изучать теорию музыки с нуля,расшифровывать музыкальные ноты на партитуре и транспонировать их на гитаре или фортепиано.",
                    Site = "",
                    Rating = 4.5M
                };
                await partnerService.AddToCategory(FeniceRecords, "Образование");
                await partnerService.AddToSubcategory(FeniceRecords, "Курсы");
                await partnerService.CreateAsync(FeniceRecords, user6);


                var user7 = new User()
                {
                    UserName = "partner7",
                    Email = "partner7@dbcard.com"
                };
                await userManager.CreateAsync(user7, "Qwerty12345");
                await userManager.AddToRoleAsync(user7, "Partner");
                var Romstal = new Partner()
                {
                    Name = "Romstal",
                    PremiumDiscounts = new List<PremiumDiscount>()
                    {
                        new PremiumDiscount()
                        {
                            DiscountPercent = 2M,
                            AccumulatingPercent = 0.5M,
                            PriceOfDiscount = 1000,
                        },
                        new PremiumDiscount()
                        {
                            DiscountPercent = 5M,
                            AccumulatingPercent = 2M,
                            PriceOfDiscount = 5000,
                        }
                    },
                    StandartDiscounts = new List<StandartDiscount>()
                    {
                        new StandartDiscount()
                        {
                            DiscountPercent = 1.5M,
                            AmountOfDiscount = 500,
                        },
                    },
                    Filials = new List<Filial>()
                    {
                        new Filial()
                        {
                            PhoneNumber="100000045",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Uzinelor",
                            HouseNumber = "12/10"
                        },
                        new Filial()
                        {
                            PhoneNumber="100000046",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Alba-Iulia",
                            HouseNumber = "75"
                        },
                        new Filial()
                        {
                            PhoneNumber="100000047",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Calea Orheiului",
                            HouseNumber = "101"
                        },
                        new Filial()
                        {
                            PhoneNumber="100000048",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Decebal",
                            HouseNumber = "1"
                        },
                        new Filial()
                        {
                            PhoneNumber="100000049",
                            Region = "Кишинев",
                            City = "Кишинев",
                            Street = "Alecu Russo",
                            HouseNumber = "61/6"
                        }
                    },
                    Description = "Suntem prezenți pe piața echipamentelor și instalațiilor de peste 10 ani, iar în această perioadă, misiunea noastră a fost performanța continuă și depășirea așteptărilor clienților noștri.",
                    Site = "romstal.md",
                    Rating = 4.5M
                };
                await partnerService.AddToCategory(Romstal, "Для дома");
                await partnerService.AddToSubcategory(Romstal, "Прочее");
                await partnerService.CreateAsync(Romstal, user7);


            }
        }

        public static async Task SeedCustomers(UserManager<User> userManager, DbCardContext context, ICustomerService customerService, IPartnerService partnerService)
        {
            if (!context.Customers.Any())
            {
                var user = new User()
                {
                    UserName = "customer1",
                    Email = "customer1@dbcard.com"
                };
                await userManager.CreateAsync(user, "Qwerty12345");
                await userManager.AddToRoleAsync(user, "Customer");

                var customer = new Customer()
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Barcode = Guid.NewGuid().NewShortGuid(),
                    DateOfBirth = new DateTime(1999, 5, 25),
                    Gender = "Male",
                    CustomersBalances = new List<CustomersBalance>()
                    {
                        new CustomersBalance()
                        {
                            Amount = 1000,
                            IsPremium = true,
                            PartnerId = await partnerService.GetIdByName("N1"),
                        },
                        new CustomersBalance()
                        {
                            Amount = 2300,
                            IsPremium = true,
                            PartnerId = await partnerService.GetIdByName("Andy's"),
                        },
                        new CustomersBalance()
                        {
                            Amount = 5100,
                            IsPremium = true,
                            PartnerId = await partnerService.GetIdByName("Darwin"),
                        },
                        new CustomersBalance()
                        {
                            Amount = 5256,
                            IsPremium = true,
                            PartnerId = await partnerService.GetIdByName("Vizaje-Nica"),
                        },
                        new CustomersBalance()
                        {
                            Amount = 7000,
                            IsPremium = true,
                            PartnerId = await partnerService.GetIdByName("Patria")
                        },
                        new CustomersBalance()
                        {
                            Amount = 1000,
                            IsPremium = false,
                            PartnerId = await partnerService.GetIdByName("Fenice Records"),
                            ResetDate = new DateTime(2020,05,31)
                        },
                        new CustomersBalance()
                        {
                            Amount = 1500,
                            IsPremium = true,
                            PartnerId = await partnerService.GetIdByName("Romstal"),
                        }
                    },
                    DateOfRegistration = DateTime.Now
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
                    },
                    Partners = new List<Partner>()
                };
                var cat2 = new Category()
                {
                    Name = "Образование",
                    Subcategories = new List<Subcategory>()
                    {
                        new Subcategory(){
                            Name = "Курсы"
                        },
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
                    },
                    Partners = new List<Partner>()
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
                    },
                    Partners = new List<Partner>()
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
                            Name = "Косметика"
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
                    },
                    Partners = new List<Partner>()
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
                    },
                    Partners = new List<Partner>()
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
                    },
                    Partners = new List<Partner>()
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
                    },
                    Partners = new List<Partner>()
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
                    },
                    Partners = new List<Partner>()
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
                    },
                    Partners = new List<Partner>()
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
                    },
                    Partners = new List<Partner>()
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

        public static async Task SeedTransactions(DbCardContext context, ITransactionService transactionService, IFilialService filialService, ICustomerService customerService)
        {
            if (!context.Transactions.Any())
            {
                var customer = await customerService.GetByName("customer1");
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000012"), 500, new DateTime(2020,5,7));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000000"), 219,new DateTime(2020,3,1));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000020"), 1500,new DateTime(2019,9,25));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000028"), 158,new DateTime(2020,2,14));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000040"), 540,new DateTime(2019,3,14));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000042"), 130,new DateTime(2019,5,17));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000007"), 825,new DateTime(2020,4,19));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000045"), 1658,new DateTime(2019,8,17));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000008"), 350,new DateTime(2019,12,15));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000026"), 450,new DateTime(2019,5,23));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000027"), 981,new DateTime(2019,7,4));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000005"), 782,new DateTime(2019,12,3));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000032"), 950,new DateTime(2019,12,18));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000008"), 856,new DateTime(2019,6,7));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000007"), 150,new DateTime(2019,2,12));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000014"), 395,new DateTime(2019,3,19));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000122"), 984,new DateTime(2019,11,20));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000020"), 390,new DateTime(2019,8,26));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000027"), 151,new DateTime(2020,2,17));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000028"), 151,new DateTime(2019,8,15));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000042"), 130,new DateTime(2019,10,18));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000025"), 851,new DateTime(2019,11,3));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000028"), 57,new DateTime(2019,7,2));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000040"), 957,new DateTime(2019,9,7));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000007"), 159,new DateTime(2019,4,28));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000046"), 1965,new DateTime(2020,2,1));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000005"), 252,new DateTime(2020,5,5));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000028"), 258,new DateTime(2019,1,17));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000006"), 25,new DateTime(2020,2,4));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000049"), 151,new DateTime(2020,2,1));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000042"), 130,new DateTime(2019,7,13));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000040"), 350,new DateTime(2019,2,7));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000048"), 584,new DateTime(2019,3,16));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000000"), 516,new DateTime(2019,7,8));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000008"), 1782,new DateTime(2019,6,27));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000025"), 853,new DateTime(2019,4,10));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000046"), 756,new DateTime(2019,2,1));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000047"), 165,new DateTime(2019,5,17));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000000"), 651,new DateTime(2019,1,6));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000030"), 185,new DateTime(2019,8,26));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000049"), 151,new DateTime(2020,4,7));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000027"), 815,new DateTime(2019,11,13));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000028"), 729,new DateTime(2019,4,14));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000014"), 357,new DateTime(2019,3,28));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000046"), 1789,new DateTime(2019,7,14));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000008"), 756,new DateTime(2019,7,16));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000045"), 157,new DateTime(2020,2,4));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000122"), 1358,new DateTime(2019,4,30));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000040"), 658,new DateTime(2019,8,13));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000042"), 116,new DateTime(2019,10,16));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000028"), 398,new DateTime(2020,1,2));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000042"), 550,new DateTime(2020,2,19));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000047"), 151,new DateTime(2019,6,11));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000046"), 138,new DateTime(2019,9,30));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000046"), 151,new DateTime(2019,8,16));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000008"), 957,new DateTime(2019,5,23));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000000"), 1289,new DateTime(2019,6,8));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000048"), 980,new DateTime(2019,9,13));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000027"), 125,new DateTime(2019,5,15));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000005"), 458,new DateTime(2020,4,27));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000122"), 412,new DateTime(2019,3,28));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000014"), 896,new DateTime(2020,2,17));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000006"), 374,new DateTime(2019,12,12));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000047"), 151,new DateTime(2019,1,18));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000030"), 151,new DateTime(2020,1,9));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000122"), 359,new DateTime(2019,6,11));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000045"), 695,new DateTime(2019,5,18));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000008"), 1080,new DateTime(2019,9,3));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000005"), 581,new DateTime(2019,8,5));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000000"), 885,new DateTime(2019,7,13));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000027"), 851,new DateTime(2019,6,18));
               await transactionService.CreateTransactionAsync(customer, await filialService.GetByPhoneAsync("100000049"), 1005,new DateTime(2019,4,28));
                await context.SaveChangesAsync();
            }
        }
    }
}

