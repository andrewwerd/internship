using Microsoft.Extensions.Configuration;

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