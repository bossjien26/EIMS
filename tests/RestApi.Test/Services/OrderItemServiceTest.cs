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
    public class OrderItemServiceTest
    {
        private readonly Mock<OrderItem> _entityMock;

        private readonly Mock<IOrderItemRepository> _repoMock;

        public OrderItemServiceTest()
        {
            _entityMock = new Mock<OrderItem>();

            _repoMock = new Mock<IOrderItemRepository>();
        }

        [Test]
        async public Task ShouldGetById()
        {
            // Arrange
            _repoMock.Setup(r => r.Get(x => x.Id == 1))
                .Returns(Task.FromResult(_entityMock.Object));

            // Act
            var result = await new OrderItemService(_repoMock.Object).GetById(1);

            // Assert
            Assert.IsInstanceOf<OrderItem>(result);
        }

        [Test]
        public void ShouldGetMany()
        {
            //Arrange
            var orderItems = OrderItemSeeder.SeedMany(10, 15).AsQueryable();

            _repoMock.Setup(u => u.GetAll()).Returns(orderItems);

            //Atc
            var result = new OrderItemService(_repoMock.Object).GetMany(1, 5).ToList();

            //Assert
            Assert.IsInstanceOf<List<OrderItem>>(result);
            Assert.AreEqual(5, result.Count);
        }

        [Test]
        public void ShouldInsertOne()
        {
            //Arrange
            //Act
            //Assert
            Assert.DoesNotThrowAsync(() =>
                new OrderItemService(_repoMock.Object).Insert(_entityMock.Object)
            );
        }

        [Test]
        public void ShouldUpdate()
        {
            //Arrange
            //Act
            //Asset
            _repoMock.Setup(c => c.Get(x => x.Price == 100))
                .Returns(Task.FromResult(_entityMock.Object));

            _entityMock.Object.Price = 100;

            Assert.DoesNotThrowAsync(() =>
                new OrderItemService(_repoMock.Object).Update(_entityMock.Object)
            );
        }
    }
}