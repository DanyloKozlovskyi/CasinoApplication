using Bogus;
using Casino.DataAccess.Models;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Tests.Generators
{
    public class UsersGenerator
    {
        private static readonly Faker<User> faker = new Faker<User>()
            .RuleFor(x => x.Id, _ => Guid.NewGuid())
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber());

        public static User Generate() => faker.Generate();

        public static List<User> Generate(int count) => faker.Generate(count);
    }
}
