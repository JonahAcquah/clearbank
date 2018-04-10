using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IAccountService
    {
        Account GetAccount(string requestDebtorAccountNumber);

        void UpdateAccount(MakePaymentRequest request, Account account);
    }
}