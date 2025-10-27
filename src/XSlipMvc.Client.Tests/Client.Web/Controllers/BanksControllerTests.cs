using Microsoft.AspNetCore.Mvc;

using Moq;

using XSlipMvc.Client.Application.Services;
using XSlipMvc.Client.Domain.Entities.Banks;
using XSlipMvc.Client.Web.Controllers;
using XSlipMvc.Client.Web.ViewModels.Bank;

namespace XSlipMvc.Client.Tests.Client.Web.Controllers
{
    public class BanksControllerTests
    {
        private readonly BanksController _controller;

        private readonly Mock<IBankService> _mockBankService;
        private readonly Mock<IBankAccountService> _bankAccountServiceMock;

        private readonly List<BankAccount> _mockBankAccounts;
        private readonly List<Bank> _mockBanks;

        public BanksControllerTests()
        {
            _mockBankService = new Mock<IBankService>();
            _bankAccountServiceMock = new Mock<IBankAccountService>();

            _mockBankAccounts = new List<BankAccount>
            {
                new BankAccount(1, "123456", "00-00-00", "Main Account", 1),
                new BankAccount(2, "654321", "00-00-01", "Savings Account", 2)
            };

            _mockBanks = new List<Bank>
            {
                new Bank(1, "TSB", _mockBankAccounts)
            };

            _controller = new BanksController(_mockBankService.Object, _bankAccountServiceMock.Object);
        }

        [Fact]
        public async Task BankList_ShouldReturnView_WithCorrectViewModel()
        {
            // Arrange
            _mockBankService
                .Setup(service => service.GetAllWithAccountsAsync())
                .ReturnsAsync(_mockBanks);

            // Act
            var result = await _controller.BankList();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<List<BankViewModel>>(viewResult.Model);
        }
    }
}