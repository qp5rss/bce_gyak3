using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            // Arrange
            var AccountController = new AccountController();

            // Act
            var actualResult = AccountController.ValidateEmail(email);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [
            Test,
            TestCase("AbCdEfGhIjK", false),
            TestCase("AAAAAAAAAAA12", false),
            TestCase("abdcd12efghi", false),
            TestCase("asd", false),
            TestCase("AbCdEfgH124312", true)
        ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            // Arrange
            var AccountController = new AccountController();

            // Act
            var actualResult = AccountController.ValidatePassword(password);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
