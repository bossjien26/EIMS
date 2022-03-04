using System.Linq;
using System.Threading.Tasks;
using DbEntity;
using Entities;
using Repositories;
using Repositories.Interface;
using Services.Interface;

namespace Services
{
    public class SupplierService : ISupplierService
    {
        private ISupplierRepository _repository;

        public SupplierService(DbContextEntity dbContextEntity)
        {
            _repository = new SupplierRepository(dbContextEntity);
        }

        public SupplierService(ISupplierRepository genericRepository)
                => _repository = genericRepository;

        public async Task Insert(Supplier instance) => await _repository.Insert(instance);

        public async Task Update(Supplier instance) => await _repository.Update(instance);

        public IQueryable<Supplier> GetAll() => _repository.GetAll();

        public IQueryable<Supplier> GetMany(int index, int size)
        => _repository.GetAll()
                .Skip((index - 1) * size)
                .Take(size)
                .OrderByDescending(x => x.Id);

        public async Task<Supplier> GetById(int id) => await _repository.Get(c => c.Id == id);
    }
}