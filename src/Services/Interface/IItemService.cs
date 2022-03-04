using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Services.Interface
{
    public interface IItemService
    {
        Task Insert(Item instance);

        Task Update(Item instance);

        IQueryable<Item> GetAll();

        IQueryable<Item> GetMany(int index, int size);

        Task<Item> GetById(int id);
    }
}