using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Services.Interface
{
    public interface IClientService
    {
        Task Insert(Client instance);

        Task Update(Client instance);

        IQueryable<Client> GetAll();

        IQueryable<Client> GetMany(int index, int size);

        Task<Client> GetById(int id);
    }
}