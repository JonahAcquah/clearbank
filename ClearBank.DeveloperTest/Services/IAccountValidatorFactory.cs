using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IAccountValidatorFactory
    {
        IAccountValidator GetInstance(MakePaymentRequest request);
    }
}