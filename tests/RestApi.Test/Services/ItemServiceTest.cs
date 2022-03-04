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
    public class ItemServiceTest
    {
        private readonly Mock<Item> _entityMock;

        private readonly Mock<IItemRepository> _repoMock;

        public ItemServiceTest()
        {
            _entityMock = new Mock<Item>();

            _repoMock = new Mock<IItemRepository>();
        }

        [Test]
        async public Task ShouldGetById()
        {
            // Arrange
            _repoMock.Setup(r => r.Get(x => x.Id == 1))
                .Returns(Task.FromResult(_entityMock.Object));

            // Act
            var result = await new ItemService(_repoMock.Object).GetById(1);

            // Assert
            Assert.IsInstanceOf<Item>(result);
        }

        [Test]
        public void ShouldGetMany()
        {
            //Arrange
            var items = ItemSeeder.SeedMany(10, 15).AsQueryable();

            _repoMock.Setup(u => u.GetAll()).Returns(items);

            //Atc
            var result = new ItemService(_repoMock.Object).GetMany(1, 5).ToList();

            //Assert
            Assert.IsInstanceOf<List<Item>>(result);
            Assert.AreEqual(5, result.Count);
        }

        [Test]
        public void ShouldInsertOne()
        {
            //Arrange
            //Act
            //Assert
            Assert.DoesNotThrowAsync(() =>
                new ItemService(_repoMock.Object).Insert(_entityMock.Object)
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
                new ItemService(_repoMock.Object).Update(_entityMock.Object)
            );
        }
    }
}