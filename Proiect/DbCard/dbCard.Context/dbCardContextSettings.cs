using Microsoft.Extensions.Configuration;
using System.IO;

namespace dbCard.Context
{
    public class dbCardContextSettings
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