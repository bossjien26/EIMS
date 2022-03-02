using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;
using Entities;

namespace RestApi.Test.DatabaseSeeders
{
    public class SupplierContactSeeder
    {
        public static SupplierContact SeedOne() => SetSupplierContact().Generate();

        public static List<SupplierContact> SeedMany(int min, int max) =>
                SetSupplierContact().GenerateBetween(min, max);

        private static Faker<SupplierContact> SetSupplierContact()
        {
            return new Faker<SupplierContact>()
                .RuleFor(c => c.Id, (f) => 0)
                .RuleFor(c => c.SupplierId, (f) => f.Random.Number(10))
                .RuleFor(c => c.Phone, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Name, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Email, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Supplier, (f) => SupplierSeeder.SeedOne());
        }
    }
}