using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Moq;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests
{
    [TestFixture]
    public class AccountServiceTests
    {
        private Mock<IAccountDataStoreFactory> _accountDataStoreFactoryMock;
        private Mock<IAccountDataStore> _accountDataStoreMock;
        private AccountService _accountService;

        [SetUp]
        public void SetUp()
        {
            _accountDataStoreMock = new Mock<IAccountDataStore>();
            _accountDataStoreFactoryMock = new Mock<IAccountDataStoreFactory>();
        }

        [Test]
        public void ShouldReturnAccountDetailsCorrectly()
        {
            //Arrange
            var account = new Account{Balance = 20};
            _accountDataStoreMock.Setup(store => store.GetAccount("123")).Returns(account);
            _accountDataStoreFactoryMock.Setup(factory => factory.GetInstance()).Returns(_accountDataStoreMock.Object);
            _accountService = new AccountService(_accountDataStoreFactoryMock.Object);

            //Act
            var result = _accountService.GetAccount("123");

            //Assert
            Assert.AreSame(result, account);
        }

        [Test]
        public void ShouldUpdateAnExistingAccountsDetailsWithTheCorrectBalance()
        {
            //Arrange
            _accountDataStoreFactoryMock.Setup(factory => factory.GetInstance()).Returns(_accountDataStoreMock.Object);
            _accountService = new AccountService(_accountDataStoreFactoryMock.Object);

            //Act
            _accountService.UpdateAccount(new MakePaymentRequest{Amount = 20}, new Account{Balance = 30});

            _accountDataStoreMock.Verify(store => store.UpdateAccount(It.Is<Account>(account => account.Balance == 10)), Times.Once);
        }
    }
}
