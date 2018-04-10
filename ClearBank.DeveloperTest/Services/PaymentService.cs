using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountService _accountDataService;
        private readonly IAccountValidatorFactory _accountValidatorFactory;

        public PaymentService(IAccountService accountDataService, IAccountValidatorFactory accountValidatorFactory)
        {
            _accountDataService = accountDataService;
            _accountValidatorFactory = accountValidatorFactory;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var account = _accountDataService.GetAccount(request.DebtorAccountNumber);

            var validator = _accountValidatorFactory.GetInstance(request);
            var isValid = validator.IsValid(request, account);

            if (isValid)
            {
                _accountDataService.UpdateAccount(request, account);
                return new MakePaymentResult{Success = true};
            }

            return new MakePaymentResult { Success = false };
        }
    }
}
