
using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Repositories;
using Repositories.Interface;
using RestApi.Test.DatabaseSeeders;

namespace RestApi.Test.Repositories
{
    [TestFixture]
    public class SupplierRepositoryTest : BaseRepositoryTest
    {
        private readonly ISupplierRepository _repository;

        public SupplierRepositoryTest() => _repository = new SupplierRepository(_context);

        [Test]
        async public Task ShouldGet()
        {
            var testData = SupplierSeeder.SeedOne();
            await _repository.Insert(testData);
            var User = await _repository.Get(x => x.Id == testData.Id);
            Assert.NotNull(User);
        }

        [Test]
        async public Task ShouldGetAll()
        {
            await _repository.InsertMany(SupplierSeeder.SeedMany(5, 5));
            var users = _repository.GetAll().Take(5).ToList();
            Assert.NotNull(users);
            Assert.AreEqual(5, users.Count);
        }

        [Test]
        public void ShouldCreateError()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _repository.Insert(null));
        }

        [Test]
        public void ShouldInsert()
        {
            var data = SupplierSeeder.SeedOne();
            Assert.DoesNotThrowAsync(() => _repository.Insert(data));
            Assert.AreNotEqual(0, data.Id);
        }

        [Test]
        public void ShouldDeleteError()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _repository.Delete(null));
        }

        [Test]
        public async Task ShouldDelete()
        {
            var testData = SupplierSeeder.SeedOne();
            await _repository.Insert(testData);

            Assert.DoesNotThrowAsync(() => _repository.Delete(testData));
            Assert.IsNull(await _repository.Get(x => x.Id == testData.Id));
        }

        [Test]
        public void ShouldUpdateError()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _repository.Update(null));
        }

        [Test]
        public async Task ShouldUpdate()
        {
            var testData = SupplierSeeder.SeedOne();
            await _repository.Insert(testData);

            testData.Name = "test";
            Assert.DoesNotThrowAsync(() => _repository.Update(testData));
        }
    }
}