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
    public class SupplierContactServiceTest
    {
        private readonly Mock<SupplierContact> _entityMock;

        private readonly Mock<ISupplierContactRepository> _repoMock;

        public SupplierContactServiceTest()
        {
            _entityMock = new Mock<SupplierContact>();

            _repoMock = new Mock<ISupplierContactRepository>();
        }

        [Test]
        async public Task ShouldGetById()
        {
            // Arrange
            _repoMock.Setup(r => r.Get(x => x.Id == 1))
                .Returns(Task.FromResult(_entityMock.Object));

            // Act
            var result = await new SupplierContactService(_repoMock.Object).GetById(1);

            // Assert
            Assert.IsInstanceOf<SupplierContact>(result);
        }

        [Test]
        public void ShouldGetMany()
        {
            //Arrange
            var supplierContacts = SupplierContactSeeder.SeedMany(10, 15).AsQueryable();

            _repoMock.Setup(u => u.GetAll()).Returns(supplierContacts);

            //Atc
            var result = new SupplierContactService(_repoMock.Object).GetMany(1, 5).ToList();

            //Assert
            Assert.IsInstanceOf<List<SupplierContact>>(result);
            Assert.AreEqual(5, result.Count);
        }

        [Test]
        public void ShouldInsertOne()
        {
            //Arrange
            //Act
            //Assert
            Assert.DoesNotThrowAsync(() =>
                new SupplierContactService(_repoMock.Object).Insert(_entityMock.Object)
            );
        }

        [Test]
        public void ShouldUpdate()
        {
            //Arrange
            //Act
            //Asset
            _repoMock.Setup(c => c.Get(x => x.Name == "aaƒ"))
                .Returns(Task.FromResult(_entityMock.Object));

            _entityMock.Object.Name = "test";

            Assert.DoesNotThrowAsync(() =>
                new SupplierContactService(_repoMock.Object).Update(_entityMock.Object)
            );
        }
    }
}