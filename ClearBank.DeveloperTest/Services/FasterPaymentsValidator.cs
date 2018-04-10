using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public class FasterPaymentsValidator : IAccountValidator
    {
        public bool IsValid(MakePaymentRequest request, Account account)
        {
            return  account != null && 
                    account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments) &&
                    account.Balance >= request.Amount;
        }
    }
}