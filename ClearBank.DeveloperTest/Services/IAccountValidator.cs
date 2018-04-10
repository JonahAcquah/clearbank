using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IAccountValidator
    {
        bool IsValid(MakePaymentRequest request, Account account);
    }
}