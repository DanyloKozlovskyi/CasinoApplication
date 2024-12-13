using Casino.Controllers;
using Casino.DataAccess.Dtos;
using Casino.DataAccess.Models;
using Casino.DataAccess.Repository;
using Casino.Services;
using Casino.Tests.Generators;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Tests.Controllers
{
    public class UsersControllerTests
    {
        private Mock<ILogger<UsersController>> mockLogger;
        private Mock<IUsersService> mockUsersService;
        private UsersController usersController;

        [SetUp]
        public void SetUp()
        {
            mockLogger = new Mock<ILogger<UsersController>>();
            mockUsersService = new Mock<IUsersService>();
            usersController = new UsersController(mockUsersService.Object, mockLogger.Object);
        }

        [TearDown]
        public void TearDown()
        {
            usersController.Dispose();
        }

        [Test]
        public async Task Index_ShouldReturnIndexViewWithUsersList()
        {
            //Arrange
            var users = UsersGenerator.Generate(10);
            mockUsersService.Setup(m => m.GetPage(1, 10)).ReturnsAsync(users);

            //Act
            IActionResult result = await usersController.Index(1, 10);

            //Assert
            var viewResult = (ViewResult)result;
            viewResult.ViewData.Model.Should().BeAssignableTo<ICollection<User>>();
            viewResult.ViewData.Model.Should().Be(users);
        }

        [Test]
        public async Task Create_WhenModelValid_ShouldReturnIndexRedirectToAction()
        {
            // Arrange
            var userCreate = UserCreateGenerator.Generate();
            var users = UsersGenerator.Generate(10);
            mockUsersService.Setup(m => m.GetUsers()).ReturnsAsync(users);

            // Act
            IActionResult result = await usersController.Create(userCreate);

            // Assert
            var viewResult = (RedirectToActionResult)result;
            viewResult.ActionName.Should().Be("Index");
        }

        [Test]
        public async Task Create_WhenModelInvalid_ShouldReturnCreateView()
        {
            // Arrange
            var userCreate = UserCreateGenerator.Generate();
            usersController.ModelState.AddModelError("FirstName", "First Name can't be blank");

            // Act
            IActionResult result = await usersController.Create(userCreate);

            // Assert
            var viewResult = (ViewResult)result;
            viewResult.ViewData.Model.Should().BeAssignableTo<UserCreate>();
            viewResult.ViewData.Model.Should().Be(userCreate);
        }
    }
}
