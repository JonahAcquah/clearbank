using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountDataStore _accountDataStore;

        public AccountService(IAccountDataStoreFactory accountDataStoreFactory)
        {
            _accountDataStore = accountDataStoreFactory.GetInstance();
        }

        public Account GetAccount(string requestDebtorAccountNumber)
        {
            return _accountDataStore.GetAccount(requestDebtorAccountNumber);
        }

        public void UpdateAccount(MakePaymentRequest request, Account account)
        {
            account.Balance -= request.Amount;
            _accountDataStore.UpdateAccount(account);
        }
    }
}