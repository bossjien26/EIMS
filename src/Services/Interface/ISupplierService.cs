using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Services.Interface
{
    public interface ISupplierService
    {
        Task Insert(Supplier instance);

        Task Update(Supplier instance);

        IQueryable<Supplier> GetAll();

        IQueryable<Supplier> GetMany(int index, int size);

        Task<Supplier> GetById(int id);
    }
}