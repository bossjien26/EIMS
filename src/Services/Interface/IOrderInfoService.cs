using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Services.Interface
{
    public interface IOrderInfoService
    {
        Task Insert(OrderInfo instance);

        Task Update(OrderInfo instance);

        IQueryable<OrderInfo> GetAll();

        IQueryable<OrderInfo> GetMany(int index, int size);

        Task<OrderInfo> GetById(int id);
    }
}