using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Services.Interface
{
    public interface IClientContactService
    {
        Task Insert(ClientContact instance);

        Task Update(ClientContact instance);

        IQueryable<ClientContact> GetAll();

        IQueryable<ClientContact> GetMany(int index, int size);

        Task<ClientContact> GetById(int id);
    }
}