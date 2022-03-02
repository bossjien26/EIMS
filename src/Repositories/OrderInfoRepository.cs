using DbEntity;
using Entities;
using Repositories.Interface;

namespace Repositories
{
    public class OrderInfoRepository : GenericRepository<OrderInfo>, IOrderInfoRepository
    {
        public OrderInfoRepository(DbContextEntity context) : base(context)
        {

        }
    }
}