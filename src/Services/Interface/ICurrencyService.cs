using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Services.Interface
{
    public interface ICurrencyService
    {
        Task Insert(Currency instance);

        Task Update(Currency instance);

        IQueryable<Currency> GetAll();

        IQueryable<Currency> GetMany(int index, int size);

        Task<Currency> GetById(int id);

        Task<Currency> GetByCurrencyName(string name);
    }
}