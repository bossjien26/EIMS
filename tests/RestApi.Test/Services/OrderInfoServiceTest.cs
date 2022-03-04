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
    public class OrderInfoServiceTest
    {
        private readonly Mock<OrderInfo> _entityMock;

        private readonly Mock<IOrderInfoRepository> _repoMock;

        public OrderInfoServiceTest()
        {
            _entityMock = new Mock<OrderInfo>();

            _repoMock = new Mock<IOrderInfoRepository>();
        }

        [Test]
        async public Task ShouldGetById()
        {
            // Arrange
            _repoMock.Setup(r => r.Get(x => x.Id == 1))
                .Returns(Task.FromResult(_entityMock.Object));

            // Act
            var result = await new OrderInfoService(_repoMock.Object).GetById(1);

            // Assert
            Assert.IsInstanceOf<OrderInfo>(result);
        }

        [Test]
        public void ShouldGetMany()
        {
            //Arrange
            var orderInfos = OrderInfoSeeder.SeedMany(10, 15).AsQueryable();

            _repoMock.Setup(u => u.GetAll()).Returns(orderInfos);

            //Atc
            var result = new OrderInfoService(_repoMock.Object).GetMany(1, 5).ToList();

            //Assert
            Assert.IsInstanceOf<List<OrderInfo>>(result);
            Assert.AreEqual(5, result.Count);
        }

        [Test]
        public void ShouldInsertOne()
        {
            //Arrange
            //Act
            //Assert
            Assert.DoesNotThrowAsync(() =>
                new OrderInfoService(_repoMock.Object).Insert(_entityMock.Object)
            );
        }

        [Test]
        public void ShouldUpdate()
        {
            //Arrange
            //Act
            //Asset
            _repoMock.Setup(c => c.Get(x => x.Remark == "aaƒ"))
                .Returns(Task.FromResult(_entityMock.Object));

            _entityMock.Object.Remark = "test";

            Assert.DoesNotThrowAsync(() =>
                new OrderInfoService(_repoMock.Object).Update(_entityMock.Object)
            );
        }
    }
}