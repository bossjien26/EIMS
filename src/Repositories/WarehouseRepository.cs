using DbEntity;
using Entities;
using Repositories.Interface;

namespace Repositories
{
    public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(DbContextEntity context) : base(context)
        {

        }
    }
}