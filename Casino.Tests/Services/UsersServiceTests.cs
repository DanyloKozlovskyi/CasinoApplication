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

        [Test]
        public async Task AddUser_WhenValidUser_ShouldReturnSameUser()
        {
            // Arrange
            UserCreate userCreate = UserCreateGenerator.Generate();

            // Act 
            User user = await usersService.AddUser(userCreate);

            // Assert
            user.FirstName.Should().Be(userCreate.FirstName);
            user.LastName.Should().Be(userCreate.LastName);
            user.Email.Should().Be(userCreate.Email);
            user.PhoneNumber.Should().Be(userCreate.PhoneNumber);
        }

        [Test]
        public async Task DeleteUser_WhenIdNonExistent_ShouldThrowArgumentException()
        {
            // Arrange 
            Guid nonExistentId = Guid.NewGuid();

            // Assert
            Assert.ThrowsAsync<ArgumentException>(
                async () =>
                {
                    await usersService.DeleteUser(nonExistentId);
                }
            );
        }

        [Test]
        public async Task GetUserById_WhenIdNonExistent_ShouldReturnNull()
        {
            // Arrange 
            Guid nonExistentId = Guid.NewGuid();
            mockUsersRepository.Setup(m => m.GetUserById(nonExistentId)).ReturnsAsync(null as User);

            // Act
            User? user = await usersService.GetUserById(nonExistentId);

            // Assert
            user.Should().BeNull();
        }

        [Test]
        public async Task GetUserById_WhenIdExistent_ShouldReturnUser()
        {
            // Arrange 
            User expectedUser = UsersGenerator.Generate();
            Guid existentId = expectedUser.Id;
            mockUsersRepository.Setup(m => m.GetUserById(existentId)).ReturnsAsync(expectedUser);

            // Act
            User? actualUser = await usersService.GetUserById(existentId);

            // Assert
            expectedUser.Should().Be(actualUser);
        }

        [Test]
        public async Task UpdateUser_WhenUserDoesntExist_ShouldThrowArgumentException()
        {
            // Arrange 
            User user = UsersGenerator.Generate();

            // Assert
            Assert.ThrowsAsync<ArgumentException>(
                async () =>
                {
                    await usersService.UpdateUser(user);
                }
            );
        }

        [Test]
        public async Task UpdateUser_WhenUserExists_ShouldThrowArgumentException()
        {
            // Arrange 
            User expectedUser = UsersGenerator.Generate();
            mockUsersRepository.Setup(m => m.UserExists(expectedUser.Id)).ReturnsAsync(true);
            mockUsersRepository.Setup(m => m.UpdateUser(expectedUser)).ReturnsAsync(expectedUser);

            // Act
            var actualUser = await usersService.UpdateUser(expectedUser);

            // Assert
            actualUser.Should().Be(expectedUser);
        }

        [Test]
        public async Task GetPage_ShouldReturnUsers()
        {
            // Arrange 
            int countUsers = 10;
            int maxPageSize = 4;
            var allUsers = UsersGenerator.Generate(countUsers);

            Random random = new Random();
            int pageSize = random.Next(1, maxPageSize);
            int page = random.Next(1, int.MaxValue) % (int)Math.Ceiling(((double)countUsers / pageSize));

            ICollection<User> expectedPage = allUsers.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            mockUsersRepository.Setup(m => m.GetPage(page, pageSize)).ReturnsAsync(expectedPage);

            // Act
            var actualPage = await usersService.GetPage(page, pageSize);

            // Assert
            actualPage.Should().BeEquivalentTo(expectedPage);
        }

        [Test]
        public async Task GetPage_WhenNoUsersExist_ShouldReturnNull()
        {
            // Act
            var actualPage = await usersService.GetPage(1, 10);

            // Assert
            actualPage.Should().BeNull();
        }

        [Test]
        public async Task CountUsers_WhenNoUsersExist_ShouldReturnInt()
        {
            // Act
            var actualCountUsers = await usersService.CountUsers();

            // Assert
            actualCountUsers.Should().Be(0);
        }
    }
}
