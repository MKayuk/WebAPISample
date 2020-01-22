using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebAPI.Infrastructure.Common
{
    public class Config
    {
        public IConfigurationRoot configuration { get; set; }
        public Config()
        {
            configuration = new ConfigurationBuilder()
                .AddJsonFile(
                    Path.Combine(
                        Directory.GetCurrentDirectory(), "dbsettings.json"
                        )
                    ).Build();
        }
    }
}
