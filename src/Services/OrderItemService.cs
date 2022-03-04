using System.Linq;
using System.Threading.Tasks;
using DbEntity;
using Entities;
using Repositories;
using Repositories.Interface;
using Services.Interface;

namespace Services
{
    public class OrderItemService : IOrderItemService
    {
        private IOrderItemRepository _repository;

        public OrderItemService(DbContextEntity dbContextEntity)
        {
            _repository = new OrderItemRepository(dbContextEntity);
        }

        public OrderItemService(IOrderItemRepository genericRepository)
                => _repository = genericRepository;

        public async Task Insert(OrderItem instance) => await _repository.Insert(instance);

        public async Task Update(OrderItem instance) => await _repository.Update(instance);

        public IQueryable<OrderItem> GetAll() => _repository.GetAll();

        public IQueryable<OrderItem> GetMany(int index, int size)
        => _repository.GetAll()
                .Skip((index - 1) * size)
                .Take(size)
                .OrderByDescending(x => x.Id);

        public async Task<OrderItem> GetById(int id) => await _repository.Get(c => c.Id == id);
    }
}