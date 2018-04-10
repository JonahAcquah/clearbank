using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests
{
    [TestFixture]
    public class AccountValidatorFactoryTests
    {
        private AccountValidatorFactory _accountValidatorFactory;

        [SetUp]
        public void SetUp()
        {
            _accountValidatorFactory = new AccountValidatorFactory();
        }

        [Test]
        public void ShouldReturnBacsValidator()
        {
            //Act
            var result = _accountValidatorFactory.GetInstance(new MakePaymentRequest{PaymentScheme = PaymentScheme.Bacs});

            //Assert
            Assert.IsInstanceOf<BacsValidator>(result);
        }

        [Test]
        public void ShouldReturnFasterPaymentsValidator()
        {
            //Act
            var result = _accountValidatorFactory.GetInstance(new MakePaymentRequest{PaymentScheme = PaymentScheme.FasterPayments});

            //Assert
            Assert.IsInstanceOf<FasterPaymentsValidator>(result);
        }

        [Test]
        public void ShouldReturnChapsValidator()
        {
            //Act
            var result = _accountValidatorFactory.GetInstance(new MakePaymentRequest{PaymentScheme = PaymentScheme.Chaps});

            //Assert
            Assert.IsInstanceOf<ChapsValidator>(result);
        }
    }
}
