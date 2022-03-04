using System.Linq;
using System.Threading.Tasks;
using DbEntity;
using Entities;
using Repositories;
using Repositories.Interface;
using Services.Interface;

namespace Services
{
    public class WarehouseService : IWarehouseService
    {
        private IWarehouseRepository _repository;

        public WarehouseService(DbContextEntity dbContextEntity)
        {
            _repository = new WarehouseRepository(dbContextEntity);
        }

        public WarehouseService(IWarehouseRepository genericRepository)
                => _repository = genericRepository;

        public async Task Insert(Warehouse instance) => await _repository.Insert(instance);

        public async Task Update(Warehouse instance) => await _repository.Update(instance);

        public IQueryable<Warehouse> GetAll() => _repository.GetAll();

        public IQueryable<Warehouse> GetMany(int index, int size)
        => _repository.GetAll()
                .Skip((index - 1) * size)
                .Take(size)
                .OrderByDescending(x => x.Id);

        public async Task<Warehouse> GetById(int id) => await _repository.Get(c => c.Id == id);
    }
}
