using System.Linq;
using System.Threading.Tasks;
using DbEntity;
using Entities;
using Repositories;
using Repositories.Interface;
using Services.Interface;

namespace Services
{
    public class OrderInfoService : IOrderInfoService
    {
        private IOrderInfoRepository _repository;

        public OrderInfoService(DbContextEntity dbContextEntity)
        {
            _repository = new OrderInfoRepository(dbContextEntity);
        }

        public OrderInfoService(IOrderInfoRepository genericRepository)
                => _repository = genericRepository;

        public async Task Insert(OrderInfo instance) => await _repository.Insert(instance);

        public async Task Update(OrderInfo instance) => await _repository.Update(instance);

        public IQueryable<OrderInfo> GetAll() => _repository.GetAll();

        public IQueryable<OrderInfo> GetMany(int index, int size)
        => _repository.GetAll()
                .Skip((index - 1) * size)
                .Take(size)
                .OrderByDescending(x => x.Id);

        public async Task<OrderInfo> GetById(int id) => await _repository.Get(c => c.Id == id);
    }
}