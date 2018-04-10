using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public class AccountValidatorFactory : IAccountValidatorFactory
    {
        public IAccountValidator GetInstance(MakePaymentRequest request)
        {
            switch (request.PaymentScheme)
            {
                case PaymentScheme.Bacs:
                    return new BacsValidator();
                case PaymentScheme.FasterPayments:
                    return new FasterPaymentsValidator();
                case PaymentScheme.Chaps:
                    return new ChapsValidator();
                default:
                    return new NullValidator();
            }
        }
    }
}