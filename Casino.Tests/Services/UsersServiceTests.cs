using Casino.DataAccess.Dtos;
using Casino.DataAccess.Models;
using Casino.DataAccess.Repository;
using Casino.Services;
using Casino.Tests.Generators;
using FluentAssertions;
using Microsoft.Identity.Client.Extensions.Msal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Tests.Services
{
    [TestFixture]
    public class UsersServiceTests
    {
        private IUsersService usersService;
        private Mock<IUsersRepository> mockUsersRepository;

        [SetUp]
        public void SetUp()
        {
            mockUsersRepository = new Mock<IUsersRepository>();
            usersService = new UsersService(mockUsersRepository.Object);
        }

        [Test]
        public async Task GetUsers_ShouldReturnAllUsers()
        {
            // Arrange
            ICollection<User> expectedUsers = UsersGenerator.Generate(5);
            mockUsersRepository.Setup(m => m.GetUsers()).ReturnsAsync(expectedUsers);

            // Act
            var actualUsers = await usersService.GetUsers();


            // Assert
            actualUsers.Should().BeEquivalentTo(expectedUsers);
        }

        [Test]
        public async Task GetUsers_WhenNoUsersExist_ShouldReturnNull()
        {
            // Act
            var actualUsers = await usersService.GetUsers();

            // Assert
            actualUsers.Should().BeNull();
        }

        [Test]
        public async Task AddUser_WhenNull_ShouldThrowArgumentNullException()
        {
            // Assert
            Assert.ThrowsAsync<ArgumentNullException>(
                async () =>
                {
                    await usersService.AddUser(null);
                }
            );
        }
    }
}
