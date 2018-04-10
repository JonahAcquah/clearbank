using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests
{
    [TestFixture]
    public class ChapsValidatorTests
    {
        private ChapsValidator _chapsValidator;

        [SetUp]
        public void SetUp()
        {
            _chapsValidator = new ChapsValidator();
        }

        [Test]
        public void ShouldValidateSuccessfullyOnlyIfAccountExistsAndChapsIsAllowedAndAccountIsActive()
        {
            //Act
            var result = _chapsValidator.IsValid(
                new MakePaymentRequest(), 
                new Account
                {
                    AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                    Status = AccountStatus.Live
                });

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldFailValidationIfAccountExistsAndChapsIsAllowedAndAccountIsDisabled()
        {
            //Act
            var result = _chapsValidator.IsValid(
                new MakePaymentRequest(), 
                new Account
                {
                    AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                    Status = AccountStatus.Disabled
                });

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldFailValidationIfAccounntExistsAndChapsIsAllowedAndAccountIsNotActive()
        {
            //Act
            var result = _chapsValidator.IsValid(
                new MakePaymentRequest(), 
                new Account
                {
                    AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                    Status = AccountStatus.InboundPaymentsOnly
                });

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldFailValidationIfAccountDoesNotExists()
        {
            //Act
            var result = _chapsValidator.IsValid(
                new MakePaymentRequest(), 
                null);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
