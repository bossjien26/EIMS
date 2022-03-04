using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Moq;
using NUnit.Framework;
using Repositories.Interface;
using RestApi.Test.DatabaseSeeders;
using Services;

namespace RestApi.Test.Services
{
    [TestFixture]
    public class CurrencyServiceTest
    {
        private readonly Mock<Currency> _entityMock;

        private readonly Mock<ICurrencyRepository> _repoMock;

        public CurrencyServiceTest()
        {
            _entityMock = new Mock<Currency>();

            _repoMock = new Mock<ICurrencyRepository>();
        }

        [Test]
        async public Task ShouldGetById()
        {
            // Arrange
            _repoMock.Setup(r => r.Get(x => x.Id == 1))
                .Returns(Task.FromResult(_entityMock.Object));

            // Act
            var result = await new CurrencyService(_repoMock.Object).GetById(1);

            // Assert
            Assert.IsInstanceOf<Currency>(result);
        }

        [Test]
        public void ShouldGetMany()
        {
            //Arrange
            var currencies = CurrencySeeder.SeedMany(10, 15).AsQueryable();

            _repoMock.Setup(u => u.GetAll()).Returns(currencies);

            //Atc
            var result = new CurrencyService(_repoMock.Object).GetMany(1, 5).ToList();

            //Assert
            Assert.IsInstanceOf<List<Currency>>(result);
            Assert.AreEqual(5, result.Count);
        }

        [Test]
        public void ShouldInsertOne()
        {
            //Arrange
            //Act
            //Assert
            Assert.DoesNotThrowAsync(() =>
                new CurrencyService(_repoMock.Object).Insert(_entityMock.Object)
            );
        }

        [Test]
        public void ShouldUpdate()
        {
            //Arrange
            //Act
            //Asset
            _repoMock.Setup(c => c.Get(x => x.Name == "aa"))
                .Returns(Task.FromResult(_entityMock.Object));

            _entityMock.Object.Name = "test";

            Assert.DoesNotThrowAsync(() =>
                new CurrencyService(_repoMock.Object).Update(_entityMock.Object)
            );
        }
    }
}