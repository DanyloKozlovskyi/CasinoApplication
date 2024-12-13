using Bogus;
using Casino.DataAccess.Dtos;
using Casino.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Tests.Generators
{
    public class UserCreateGenerator
    {
        private static readonly Faker<UserCreate> faker = new Faker<UserCreate>()
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber());

        public static UserCreate Generate() => faker.Generate();

        public static List<UserCreate> Generate(int count) => faker.Generate(count);
    }
}
