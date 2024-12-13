using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DataAccess.Models.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // here we can seed data and set foreign keys
            builder.HasData(
                new User() { Id = Guid.Parse("52FDF31C-27C4-498B-BAD3-D56394B8D51D"), FirstName = "John", LastName = "Robinson", Email = "john@gmail.com", PhoneNumber = "1234567890" },
                new User() { Id = Guid.Parse("1109A562-AA69-4D01-8EBA-10175EEAAD5C"), FirstName = "Mark", LastName = "Bremer", Email = "bremer@gmail.com", PhoneNumber = "1234567890" },
                new User() { Id = Guid.Parse("74757949-C32B-44EA-A7D0-0BF457B8A90E"), FirstName = "Jack", LastName = "Richardson", Email = "jackrich@gmail.com", PhoneNumber = "0987654321" },
                new User() { Id = Guid.Parse("8FC92E40-F91F-40BF-89FF-5E68578D4367"), FirstName = "Joseph", LastName = "Borr", Email = "joseph@gmail.com", PhoneNumber = "1234567890" },
                new User() { Id = Guid.Parse("074CDD40-BE99-456D-9740-791ABD93024F"), FirstName = "Max", LastName = "Bart", Email = "bart@gmail.com", PhoneNumber = "0987654321" },
                new User() { Id = Guid.Parse("DF44D370-E174-4426-A52E-58A260F704EB"), FirstName = "Nicholas", LastName = "Spencer", Email = "spencer@gmail.com", PhoneNumber = "1234567890" },
                new User() { Id = Guid.Parse("6D6B0494-EDB0-439C-9FEF-7D4BB5CB71F3"), FirstName = "Eugene", LastName = "Lagelle", Email = "eugene@gmail.com", PhoneNumber = "0987654321" },
                new User() { Id = Guid.Parse("3ED704F4-40AA-42E2-8119-A6C6DAABA0A6"), FirstName = "Richard", LastName = "Thudor", Email = "thudor@gmail.com", PhoneNumber = "1234567890" },
                new User() { Id = Guid.Parse("D7E63A43-A93B-42ED-AA8F-727C75E53CDA"), FirstName = "Andrew", LastName = "Bock", Email = "bock@gmail.com", PhoneNumber = "0987654321" },
                new User() { Id = Guid.Parse("D46DEFD8-526B-4D86-B903-412F59673B2D"), FirstName = "George", LastName = "Bluementhal", Email = "bluementhal@gmail.com", PhoneNumber = "1234567890" },
                new User() { Id = Guid.Parse("95DA71D2-830B-4DA6-8C35-55A96AA2487E"), FirstName = "Marry", LastName = "Smith", Email = "smithm@gmail.com", PhoneNumber = "0987654321" },
                new User() { Id = Guid.Parse("8558B449-4562-4234-A78F-2996681BFF6A"), FirstName = "Rudolf", LastName = "Hampspring", Email = "rudhampspring@gmail.com", PhoneNumber = "1234567890" }
                );
        }
    }
}
