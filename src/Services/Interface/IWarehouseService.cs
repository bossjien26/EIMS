using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Services.Interface
{
    public interface IWarehouseService
    {
        Task Insert(Warehouse instance);

        Task Update(Warehouse instance);

        IQueryable<Warehouse> GetAll();

        IQueryable<Warehouse> GetMany(int index, int size);

        Task<Warehouse> GetById(int id);
    }
}