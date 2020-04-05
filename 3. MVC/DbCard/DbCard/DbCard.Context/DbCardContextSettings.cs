using Microsoft.Extensions.Configuration;
using System.IO;

namespace DbCard.Context
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