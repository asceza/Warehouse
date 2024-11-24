using NUnit.Framework;
using Warehouse.WebUI.Services;

namespace Warehouse.Tests
{
    public class AuthServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("������")]
        [TestCase("������")]
        [TestCase("�������")]
        public void Login_ShouldReturnTrue(string lastName)
        {
            // arrange
            var service = new AuthService();

            // act
            var result = service.Login(lastName);

            // assert
            Assert.IsTrue(result);
        }


        [TestCase("")]
        [TestCase(null)]
        [TestCase("User1")]
        public void Login_ShouldReturnFalse(string lastName)
        {
            // arrange
            var service = new AuthService();

            // act
            var result = service.Login(lastName);

            // assert
            Assert.IsFalse(result);
        }
    }
}