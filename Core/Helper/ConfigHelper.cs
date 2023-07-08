using Microsoft.Extensions.Configuration;

namespace Core.Helper
{
    public static class ConfigHelper
    {
        private static IConfiguration _appSetting { get; set; }

        public static void Init(IConfiguration appSetting)
        {
            _appSetting = appSetting;
        }

        public static Config GetBaseConfig()
        {
            return _appSetting.GetSection("Base").Get<Config>() ?? new Config();
        }

        public static string GetConnectionString()
        {
            return _appSetting.GetConnectionString("DefaultConnection") ?? "";
        }
    }

    public class Config
    {
        public string DbType { get; set; } = string.Empty;
    }
}
