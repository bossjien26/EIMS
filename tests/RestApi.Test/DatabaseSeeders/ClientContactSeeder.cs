using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;
using Entities;

namespace RestApi.Test.DatabaseSeeders
{
    public class ClientContactSeeder
    {
        public static ClientContact SeedOne() => SetClientContact().Generate();

        public static List<ClientContact> SeedMany(int min, int max) =>
                SetClientContact().GenerateBetween(min, max);

        private static Faker<ClientContact> SetClientContact()
        {
            return new Faker<ClientContact>()
                .RuleFor(c => c.Id, (f) => 0)
                .RuleFor(c => c.ClientId, (f) => f.Random.Number(10))
                .RuleFor(c => c.Phone, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Name, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Email, (f) => f.Random.AlphaNumeric(10))
                .RuleFor(c => c.Client, (f) => ClientSeeder.SeedOne());
        }
    }
}