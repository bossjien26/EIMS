using DbEntity;
using Entities;
using Repositories.Interface;

namespace Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DbContextEntity context) : base(context)
        {

        }
    }
}