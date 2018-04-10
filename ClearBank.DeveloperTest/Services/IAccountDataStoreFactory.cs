using ClearBank.DeveloperTest.Data;

namespace ClearBank.DeveloperTest.Services
{
    public interface IAccountDataStoreFactory
    {
        IAccountDataStore GetInstance();
    }

    public class AccountDataStoreFactory : IAccountDataStoreFactory
    {
        private readonly IConfigSettings _configSettings;

        public AccountDataStoreFactory(IConfigSettings configSettings)
        {
            _configSettings = configSettings;
        }

        public IAccountDataStore GetInstance()
        {
            if (_configSettings.GetDataStoreType == "Backup")
                return new BackupAccountDataStore();

            return new AccountDataStore();
        }
    }
}