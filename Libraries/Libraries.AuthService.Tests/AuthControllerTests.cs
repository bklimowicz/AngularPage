using Libraries.AuthService.Controllers;
using Libraries.AuthService.Services;
using FluentAssertions;
using Xunit;
using System;
using System.Linq;
using Libraries.AuthService.Data;
using Moq;

namespace Libraries.AuthService.Tests;

public class AuthControllerTests
{
    private readonly AuthController _authController;
    

    public AuthControllerTests()
    {
        var mockUserRepository = new Mock<IUserRepository>();

        this._authController = new AuthController(mockUserRepository.Object);
    }

    [Fact]
    public void AuthControllerExists()
    {
        this._authController.Should().NotBeNull();
    }    

    [Theory]
    [InlineData("test", "test")]
    public void GivenUserInfoThenReturnToken(string userName, string password)
    {
        // Arrange
        UserAuthService authService = new UserAuthService();

        // Act
        string token = authService.LoginUser(userName, password);

        // Assert
        token.Should().BeOfType<string>();
        token.Should().Equals("test");
    }

    [Fact]
    public void AuthControllerHasIUserRepositoryDependency()
    {
        var constructor = typeof(AuthController).GetConstructors()[0];
        var parameters = constructor.GetParameters().ToList();

        var result = parameters.Any(p => typeof(IUserRepository).IsAssignableFrom(p.ParameterType));

        result.Should().BeTrue();
    }

    [Fact]
    public void AuthControllerHasOneConstructor()
    {
        var constructors = typeof(AuthController).GetConstructors();

        constructors.Length.Should().Be(1);
    }
}
