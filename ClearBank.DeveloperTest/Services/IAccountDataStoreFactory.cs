namespace ClearBank.DeveloperTest.Services
{
    public interface IAccountDataStoreFactory
    {
        IAccountDataStore GetInstance();
    }
}