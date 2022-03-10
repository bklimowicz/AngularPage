using CouchDBConnector.Controllers;
using CouchDBConnector.Model;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Libraries.Tests
{
    public class TestUsersController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange(setup system under tests, objects etc)
            var mockUsersService = new Mock<IUsersService>();
            mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());

            var sut = new UsersController(mockUsersService.Object);// sut = system under test

            // Act (calling methods to test on Arranged objects)
            var result = (OkObjectResult)await sut.Get();

            // Assert (Making an assertion about output of Act)
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_InvokesUserServiceExactlyOnce()
        {
            // Arrange
            var mockUsersService = new Mock<IUsersService>();

            mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());

            var sut = new UsersController(mockUsersService.Object);

            // Act
            var result = await sut.Get();

            // Assert
            mockUsersService.Verify(
                service => service.GetAllUsers(),
                Times.Once());
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnsListOfUsers()
        {
            // Arrange
            var mockUsersService = new Mock<IUsersService>();

            mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());

            var sut = new UsersController(mockUsersService.Object);

            // Act
            var result = await sut.Get();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<User>>();
        }
    }
}