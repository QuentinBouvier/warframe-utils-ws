using System;
using System.Threading.Tasks;
using MarketProxy.Controllers;
using MarketProxy.Model;
using MarketProxy.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace TestProxy
{
    public class MarketProxyControllerTest
    {
        private Mock<IProxySnapshotRepository> MockRepository { get; set; }
        private MarketProxyController Controller { get; set; }

        [SetUp]
        public void Setup()
        {
            this.MockRepository = new Mock<IProxySnapshotRepository>();
            this.Controller = new MarketProxyController(this.MockRepository.Object);
        }

        [Test]
        public async Task Get_Returns200WithAnUniqueObjectWhenQueriedWithAnExistingName()
        {
            // Arrange
            MarketSnapshot mockSnapshot = new MarketSnapshot()
            {
                Date = DateTime.UtcNow,
                Id = "5f7dad107cc5dd687ec9a586",
                Name = "orthos_prime_blade",
                Payload = @"I am the baaaaaaaad payload"
            };
            this.MockRepository.Setup(x => x.FindByName("orthos_prime_blade")).Returns(Task.FromResult(mockSnapshot));

            // Act
            var result = (ObjectResult) await this.Controller.Get("orthos_prime_blade");

            // Assert
            Assert.AreEqual(result.StatusCode, 200);
            Assert.AreEqual(mockSnapshot, result.Value);
        }

        [Test]
        public async Task Get_Returns404WhenNameDoesNotExist()
        {
            // Arrange
            this.MockRepository.Setup(x => x.FindByName("")).Returns(Task.FromResult<MarketSnapshot>(null));

            // Act
            var result = (StatusCodeResult) await this.Controller.Get("");

            // Assert
            Assert.AreEqual(result.StatusCode, 404);
        }
    }
}