using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.DataLayer.Models;
using VendingMachine.Domain.Repositories;
using VendingMachine.Domain.Services;

namespace VendingMachine.Tests
{
    [TestFixture]
    public class AuthenticatorTests
    {
        private AuthenticationServices _authenticationService;
        private Mock<IAccountServices> _mockAccountService;

        [SetUp]
        public void SetUp()
        {
            _mockAccountService = new Mock<IAccountServices>();
            _authenticationService = new AuthenticationServices(_mockAccountService.Object);
        }

        [Test]
        public async Task Login_WithCorrectPasswordForExistingUser_ReturnsUserForCorrectUserName()
        {
            // Arrange
            string ex_username = "testuser";
            string ex_password = "testpass";
            _mockAccountService.Setup(s => s.GetByUserName(ex_username)).
                ReturnsAsync(new User() { UserName = ex_username, Passwword = ex_password } );
            // Act
            User account = await _authenticationService.Login(ex_username, ex_password);

            //Assert
            string act_Username = account.UserName;
            Assert.AreEqual(ex_username, act_Username);
        }

        [Test]
        public void Login_WithInCorrectPasswordForExistingUser_ThrowsExceptionForeUserName()
        {
            // Arrange
            string ex_username = "testuser";
            string ex_password = "testpass";
            _mockAccountService.Setup(s => s.GetByUserName(ex_username)).
                ReturnsAsync( new User() { UserName = ex_username, Passwword = "WrongPassword" });

            // Act
            Exception exception = Assert.ThrowsAsync<Exception>(() => _authenticationService.Login(ex_username, ex_password));

            //Assert
            string exception = "Wrong Password";
            Assert.AreEqual(ex_username, act_Username);
        }
    }
}
