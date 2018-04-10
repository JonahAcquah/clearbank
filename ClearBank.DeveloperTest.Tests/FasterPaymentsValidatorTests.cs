using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests
{
    [TestFixture]
    public class FasterPaymentsValidatorTests
    {
        private FasterPaymentsValidator _fasterPaymentsValidator;

        [SetUp]
        public void SetUp()
        {
            _fasterPaymentsValidator = new FasterPaymentsValidator();
        }

        [Test]
        public void ShouldValidateSuccessfullyOnlyIfAccountExistsAndFasterPaymentsIsAllowedAndCustomerHasEnoughFunds()
        {
            //Act
            var result = _fasterPaymentsValidator.IsValid(
                new MakePaymentRequest{Amount = 20}, 
                new Account
                {
                    AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                    Balance = 30
                });

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldFailValidationIfAccountExistsAndFasterPaymentsIsAllowedButCustomerHasLessFundsThanRequested()
        {
            //Act
            var result = _fasterPaymentsValidator.IsValid(
                new MakePaymentRequest{Amount = 20}, 
                new Account
                {
                    AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                    Balance = 19
                });

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldFailValidationIfAccountExistsAndFasterPaymentsIsNotEnabledAndCustomerHasEnoughFunds()
        {
            //Act
            var result = _fasterPaymentsValidator.IsValid(
                new MakePaymentRequest { Amount = 20 },
                new Account
                {
                    AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                    Balance = 30
                });

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldFailValidationIfAccountDoesNotExist()
        {
            //Act
            var result = _fasterPaymentsValidator.IsValid(
                new MakePaymentRequest { Amount = 20 },
                null);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
