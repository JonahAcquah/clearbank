using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public class NullValidator : IAccountValidator
    {
        public bool IsValid(MakePaymentRequest request, Account account)
        {
            return false;
        }
    }
}