using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;
using Entities;

namespace RestApi.Test.DatabaseSeeders
{
    public class CurrencySeeder
    {
        public static Currency SeedOne() => SetCurrency().Generate();

        public static List<Currency> SeedMany(int min, int max) =>
                SetCurrency().GenerateBetween(min, max);

        private static Faker<Currency> SetCurrency()
        {
            return new Faker<Currency>()
                .RuleFor(c => c.Id, (f) => 0)
                .RuleFor(c => c.Name, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.ExchangeRate, (f) => f.Random.Number(10));
        }
    }
}