using DbEntity;
using Entities;
using Repositories.Interface;

namespace Repositories
{
    public class ClientContactRepository : GenericRepository<ClientContact>, IClientContactRepository
    {
        public ClientContactRepository(DbContextEntity context) : base(context)
        {

        }
    }
}