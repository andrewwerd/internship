using Microsoft.Extensions.Configuration;

namespace dbCard.Context
{
    public class dbCardSettings
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