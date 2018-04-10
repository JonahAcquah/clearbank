using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests
{
    [TestFixture]
    public class BacsValidatorTests
    {
        private BacsValidator _bacsValidator;

        [SetUp]
        public void SetUp()
        {
            _bacsValidator = new BacsValidator();
        }

        [Test]
        public void ShouldValidateSuccessfullyOnlyIfBacsIsAllowedAndAccountExists()
        {
            //Act
            var result = _bacsValidator.IsValid(new MakePaymentRequest(), new Account{AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs});

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldFailValidationIfBacsIsNotAllowedAndAccountExists()
        {
            //Act
            var result = _bacsValidator.IsValid(new MakePaymentRequest(), new Account{AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments});

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldFailValidationIfAnAccountDoesNotExist()
        {
            //Act
            var result = _bacsValidator.IsValid(new MakePaymentRequest(), null);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
