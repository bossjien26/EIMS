using DbEntity;
using Entities;
using Repositories.Interface;

namespace Repositories
{
    public class SupplierContactRepository : GenericRepository<SupplierContact>, ISupplierContactRepository
    {
        public SupplierContactRepository(DbContextEntity context) : base(context)
        {

        }
    }
}