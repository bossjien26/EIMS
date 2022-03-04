using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Services.Interface
{
    public interface IOrderItemService
    {
        Task Insert(OrderItem instance);

        Task Update(OrderItem instance);

        IQueryable<OrderItem> GetAll();

        IQueryable<OrderItem> GetMany(int index, int size);

        Task<OrderItem> GetById(int id);
    }
}