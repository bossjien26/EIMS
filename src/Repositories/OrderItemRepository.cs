using DbEntity;
using Entities;
using Repositories.Interface;

namespace Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(DbContextEntity context) : base(context)
        {

        }
    }
}