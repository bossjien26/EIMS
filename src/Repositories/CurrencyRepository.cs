using DbEntity;
using Entities;
using Repositories.Interface;

namespace Repositories
{
    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(DbContextEntity context) : base(context)
        {

        }
    }
}