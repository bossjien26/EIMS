using DbEntity;
using Entities;
using Repositories.Interface;

namespace Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(DbContextEntity context) : base(context)
        {

        }
    }
}