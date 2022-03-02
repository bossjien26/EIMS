using DbEntity;
using Entities;
using Repositories.Interface;

namespace Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(DbContextEntity context) : base(context)
        {

        }
    }
}