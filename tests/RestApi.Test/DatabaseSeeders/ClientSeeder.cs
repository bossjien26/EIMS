using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;
using Entities;

namespace RestApi.Test.DatabaseSeeders
{
    public class ClientSeeder
    {
        public static Client SeedOne() => SetClient().Generate();

        public static List<Client> SeedMany(int min, int max) =>
                SetClient().GenerateBetween(min, max);

        private static Faker<Client> SetClient()
        {
            return new Faker<Client>()
                .RuleFor(c => c.Id, (f) => 0)
                .RuleFor(c => c.Address, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Company, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Name, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Phone, (f) => f.Random.AlphaNumeric(10));
        }
    }
}