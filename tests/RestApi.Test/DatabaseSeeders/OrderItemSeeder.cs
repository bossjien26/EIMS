using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;
using Entities;
using Enum;

namespace RestApi.Test.DatabaseSeeders
{
    public class OrderItemSeeder
    {
        public static OrderItem SeedOne() => SetOrderItem().Generate();

        public static List<OrderItem> SeedMany(int min, int max) =>
                SetOrderItem().GenerateBetween(min, max);

        private static Faker<OrderItem> SetOrderItem()
        {
            return new Faker<OrderItem>()
                .RuleFor(c => c.Id, (f) => 0)
                .RuleFor(c => c.OrderId, (f) => f.Random.Number(10))
                .RuleFor(c => c.ItemId, (f) => f.Random.Number(10))
                .RuleFor(c => c.Specification, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Quantity, (f) => f.Random.Number(10))
                .RuleFor(c => c.Price, (f) => f.Random.Float(1, 10))
                .RuleFor(c => c.Item, (f) => ItemSeeder.SeedOne())
                .RuleFor(c => c.OrderInfo, (f) => OrderInfoSeeder.SeedOne());
        }
    }
}