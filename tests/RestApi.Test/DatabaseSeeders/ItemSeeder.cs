using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;
using Entities;

namespace RestApi.Test.DatabaseSeeders
{
    public class ItemSeeder
    {
        public static Item SeedOne() => SetItem().Generate();

        public static List<Item> SeedMany(int min, int max) =>
                SetItem().GenerateBetween(min, max);

        private static Faker<Item> SetItem()
        {
            return new Faker<Item>()
                .RuleFor(c => c.Id, (f) => 0)
                .RuleFor(c => c.WarehouseId, (f) => f.Random.Number(10))
                .RuleFor(c => c.Name, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Specification, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Quantity, (f) => f.Random.Number(10))
                .RuleFor(c => c.Price, (f) => f.Random.Float(1, 10))
                .RuleFor(c => c.Describe, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Information, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Warehouse, (f) => WarehouseSeeder.SeedOne());
        }
    }
}