using DbEntity;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace RestApi.Test.Repositories
{
    public class BaseRepositoryTest
    {
        internal readonly DbContextEntity _context;

        internal readonly IConnectionMultiplexer _redisConnect;

        public BaseRepositoryTest()
        {
            var connectionString = "Server=localhost,1433;Database=events_service;MultipleActiveResultSets=true;User=SA;Password=Passw@rd;";
            var options = new DbContextOptionsBuilder<DbContextEntity>()
                .UseSqlServer(
                   connectionString
                )
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .Options;

            _context = new DbContextEntity(options);

            _redisConnect = ConnectionMultiplexer.Connect(
                    new ConfigurationOptions
                    {
                        EndPoints = { "localhost:6379" }
                    });
        }
    }
}