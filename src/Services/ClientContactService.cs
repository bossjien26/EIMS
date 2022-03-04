using System.Linq;
using System.Threading.Tasks;
using DbEntity;
using Entities;
using Repositories;
using Repositories.Interface;
using Services.Interface;

namespace Services
{
    public class ClientContactService : IClientContactService
    {
        private IClientContactRepository _repository;

        public ClientContactService(DbContextEntity dbContextEntity)
        {
            _repository = new ClientContactRepository(dbContextEntity);
        }

        public ClientContactService(IClientContactRepository genericRepository)
                => _repository = genericRepository;

        public async Task Insert(ClientContact instance) => await _repository.Insert(instance);

        public async Task Update(ClientContact instance) => await _repository.Update(instance);

        public IQueryable<ClientContact> GetAll() => _repository.GetAll();

        public IQueryable<ClientContact> GetMany(int index, int size)
        => _repository.GetAll()
                .Skip((index - 1) * size)
                .Take(size)
                .OrderByDescending(x => x.Id);

        public async Task<ClientContact> GetById(int id) => await _repository.Get(c => c.Id == id);
    }
}