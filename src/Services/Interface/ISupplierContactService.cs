using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Services.Interface
{
    public interface ISupplierContactService
    {
        Task Insert(SupplierContact instance);

        Task Update(SupplierContact instance);

        IQueryable<SupplierContact> GetAll();

        IQueryable<SupplierContact> GetMany(int index, int size);

        Task<SupplierContact> GetById(int id);
    }
}