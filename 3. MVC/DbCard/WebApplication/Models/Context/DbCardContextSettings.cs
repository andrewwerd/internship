using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Context
{
    public class DbCardContextSettings
    {
        public static IConfigurationRoot ConfigurationRoot { get; set; }

        public static void Create()
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true);
            ConfigurationRoot = configBuilder.Build();
        }
    }
}
