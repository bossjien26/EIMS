using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;
using Entities;
using Enum;

namespace RestApi.Test.DatabaseSeeders
{
    public class WarehouseSeeder
    {
        public static Warehouse SeedOne() => SetWarehouse().Generate();

        public static List<Warehouse> SeedMany(int min, int max) =>
                SetWarehouse().GenerateBetween(min, max);

        private static Faker<Warehouse> SetWarehouse()
        {
            return new Faker<Warehouse>()
                .RuleFor(c => c.Id, (f) => 0)
                .RuleFor(c => c.Type, (f) => WarehouseEnum.Export)
                .RuleFor(c => c.Address, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Name, (f) => f.Random.AlphaNumeric(10));
        }
    }
}