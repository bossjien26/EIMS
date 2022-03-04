using System.Linq;
using System.Threading.Tasks;
using DbEntity;
using Entities;
using Repositories;
using Repositories.Interface;
using Services.Interface;

namespace Services
{
    public class ItemService : IItemService
    {
        private IItemRepository _repository;

        public ItemService(DbContextEntity dbContextEntity)
        {
            _repository = new ItemRepository(dbContextEntity);
        }

        public ItemService(IItemRepository genericRepository)
                => _repository = genericRepository;

        public async Task Insert(Item instance) => await _repository.Insert(instance);

        public async Task Update(Item instance) => await _repository.Update(instance);

        public IQueryable<Item> GetAll() => _repository.GetAll();

        public IQueryable<Item> GetMany(int index, int size)
        => _repository.GetAll()
                .Skip((index - 1) * size)
                .Take(size)
                .OrderByDescending(x => x.Id);

        public async Task<Item> GetById(int id) => await _repository.Get(c => c.Id == id);
    }
}