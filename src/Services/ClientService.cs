using System.Linq;
using System.Threading.Tasks;
using DbEntity;
using Entities;
using Repositories;
using Repositories.Interface;
using Services.Interface;

namespace Services
{
    public class ClientService : IClientService
    {
        private IClientRepository _repository;

        public ClientService(DbContextEntity dbContextEntity)
        {
            _repository = new ClientRepository(dbContextEntity);
        }

        public ClientService(IClientRepository genericRepository)
                => _repository = genericRepository;

        public async Task Insert(Client instance) => await _repository.Insert(instance);

        public async Task Update(Client instance) => await _repository.Update(instance);

        public IQueryable<Client> GetAll() => _repository.GetAll();

        public IQueryable<Client> GetMany(int index, int size)
        => _repository.GetAll()
                .Skip((index - 1) * size)
                .Take(size)
                .OrderByDescending(x => x.Id);

        public async Task<Client> GetById(int id) => await _repository.Get(c => c.Id == id);
    }
}