using System.Configuration;

namespace ClearBank.DeveloperTest.Services
{
    public interface IConfigSettings
    {
        string GetDataStoreType { get; }
    }

    public class ConfigSettings : IConfigSettings
    {
        public string GetDataStoreType => ConfigurationManager.AppSettings["DataStoreType"];
    }
}