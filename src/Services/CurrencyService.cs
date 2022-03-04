using System.Linq;
using System.Threading.Tasks;
using DbEntity;
using Entities;
using Repositories;
using Repositories.Interface;
using Services.Interface;

namespace Services
{
    public class CurrencyService : ICurrencyService
    {
        private ICurrencyRepository _repository;

        public CurrencyService(DbContextEntity dbContextEntity)
        {
            _repository = new CurrencyRepository(dbContextEntity);
        }

        public CurrencyService(ICurrencyRepository genericRepository)
                => _repository = genericRepository;

        public async Task Insert(Currency instance) => await _repository.Insert(instance);

        public async Task Update(Currency instance) => await _repository.Update(instance);

        public IQueryable<Currency> GetAll() => _repository.GetAll();

        public IQueryable<Currency> GetMany(int index, int size)
        => _repository.GetAll()
                .Skip((index - 1) * size)
                .Take(size)
                .OrderByDescending(x => x.Id);

        public async Task<Currency> GetById(int id) => await _repository.Get(c => c.Id == id);
    }
}