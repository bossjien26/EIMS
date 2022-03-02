using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;
using Entities;

namespace RestApi.Test.DatabaseSeeders
{
    public class SupplierSeeder
    {
        public static Supplier SeedOne() => SetSupplierContact().Generate();

        public static List<Supplier> SeedMany(int min, int max) =>
                SetSupplierContact().GenerateBetween(min, max);

        private static Faker<Supplier> SetSupplierContact()
        {
            return new Faker<Supplier>()
                .RuleFor(c => c.Id, (f) => 0)
                .RuleFor(c => c.Address, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Company, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Name, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Phone, (f) => f.Random.AlphaNumeric(10));
        }
    }
}