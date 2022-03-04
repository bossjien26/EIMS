using System.Linq;
using System.Threading.Tasks;
using DbEntity;
using Entities;
using Repositories;
using Repositories.Interface;
using Services.Interface;

namespace Services
{
    public class SupplierContactService : ISupplierContactService
    {
        private ISupplierContactRepository _repository;

        public SupplierContactService(DbContextEntity dbContextEntity)
        {
            _repository = new SupplierContactRepository(dbContextEntity);
        }

        public SupplierContactService(ISupplierContactRepository genericRepository)
                => _repository = genericRepository;

        public async Task Insert(SupplierContact instance) => await _repository.Insert(instance);

        public async Task Update(SupplierContact instance) => await _repository.Update(instance);

        public IQueryable<SupplierContact> GetAll() => _repository.GetAll();

        public IQueryable<SupplierContact> GetMany(int index, int size)
        => _repository.GetAll()
                .Skip((index - 1) * size)
                .Take(size)
                .OrderByDescending(x => x.Id);

        public async Task<SupplierContact> GetById(int id) => await _repository.Get(c => c.Id == id);
    }
}