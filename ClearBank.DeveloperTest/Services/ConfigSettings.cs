using System.Configuration;

namespace ClearBank.DeveloperTest.Services
{
    public class ConfigSettings : IConfigSettings
    {
        public string GetDataStoreType => ConfigurationManager.AppSettings["DataStoreType"];
    }
}