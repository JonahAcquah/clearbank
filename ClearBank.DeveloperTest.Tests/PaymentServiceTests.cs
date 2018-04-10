using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Moq;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests
{
    [TestFixture]
    public class PaymentServiceTests
    {
        private Mock<IAccountValidatorFactory> _accountValidatorFactoryMock;
        private Mock<IAccountValidator> _accountValidatorMock;
        private Mock<IAccountService> _accountServiceMock;
        private PaymentService _paymentService;

        [SetUp]
        public void SetUp()
        {
            _accountServiceMock = new Mock<IAccountService>();
            _accountValidatorMock = new Mock<IAccountValidator>();

            _accountValidatorFactoryMock = new Mock<IAccountValidatorFactory>();

            _paymentService = new PaymentService(_accountServiceMock.Object, _accountValidatorFactoryMock.Object);
        }

        [Test]
        public void ShouldNotUpdateAnAccountIfAccountIsInInvalidState()
        {
            //Arrange
            _accountValidatorMock
                .Setup(validator => validator.IsValid(It.IsAny<MakePaymentRequest>(), It.IsAny<Account>()))
                .Returns(false);

            _accountValidatorFactoryMock.Setup(factory => factory.GetInstance(It.IsAny<MakePaymentRequest>()))
                .Returns(_accountValidatorMock.Object);

            //Act
            var result = _paymentService.MakePayment(new MakePaymentRequest());

            //Assert
            Assert.IsFalse(result.Success);
        }

        [Test]
        public void ShouldUpdateAnAccountIfAccountIsInAValidState()
        {
            //Arrange
            _accountValidatorMock
                .Setup(validator => validator.IsValid(It.IsAny<MakePaymentRequest>(), It.IsAny<Account>()))
                .Returns(true);

            _accountValidatorFactoryMock.Setup(factory => factory.GetInstance(It.IsAny<MakePaymentRequest>()))
                .Returns(_accountValidatorMock.Object);

            //Act
            var result = _paymentService.MakePayment(new MakePaymentRequest());

            //Assert
            Assert.IsTrue(result.Success);
        }
    }
}
