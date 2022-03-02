using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;
using Entities;
using Enum;

namespace RestApi.Test.DatabaseSeeders
{
    public class OrderInfoSeeder
    {
        public static OrderInfo SeedOne() => SetOrderInfo().Generate();

        public static List<OrderInfo> SeedMany(int min, int max) =>
                SetOrderInfo().GenerateBetween(min, max);

        private static Faker<OrderInfo> SetOrderInfo()
        {
            return new Faker<OrderInfo>()
                .RuleFor(c => c.Id, (f) => 0)
                .RuleFor(c => c.CompanyId, (f) => f.Random.Number(10))
                .RuleFor(c => c.ContactId, (f) => f.Random.Number(10))
                .RuleFor(c => c.CurrencyId, (f) => f.Random.Number(10))
                .RuleFor(c => c.OrderNumber, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Flag, (f) => OrderFlagEnum.DeliveryOrder)
                .RuleFor(c => c.ExchangeRate, (f) => f.Random.Number(10))
                .RuleFor(c => c.Remark, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Invoice, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.InvoiceAddress, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Receipt, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Currency, (f) => CurrencySeeder.SeedOne());
        }
    }
}