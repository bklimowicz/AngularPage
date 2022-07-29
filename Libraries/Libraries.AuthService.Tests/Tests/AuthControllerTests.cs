using Libraries.AuthService.Controllers;
using FluentAssertions;
using Xunit;
using System.Linq;
using Libraries.SqlDBConnector.Data;
using Moq;
using Libraries.AuthService.Helpers;

namespace Libraries.AuthService.Tests;

public class AuthControllerTests
{
    private readonly AuthController _authController;


    public AuthControllerTests()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var mockJwtService = new Mock<IJwtService>();

        this._authController = new AuthController(mockUserRepository.Object, mockJwtService.Object);
    }

    [Fact]
    public void HasIUserRepositoryDependency()
    {
        var constructor = typeof(AuthController).GetConstructors()[0];
        var parameters = constructor.GetParameters().ToList();

        var result = parameters.Any(p => typeof(IUserRepository).IsAssignableFrom(p.ParameterType));

        result.Should().BeTrue();
    }

    [Fact]
    public void HasIJwtServiceDependency()
    {
        var constructor = typeof(AuthController).GetConstructors()[0];
        var parameters = constructor.GetParameters().ToList();

        var result = parameters.Any(p => typeof(IJwtService).IsAssignableFrom(p.ParameterType));

        result.Should().BeTrue();
    }

    [Fact]
    public void HasOneConstructor()
    {
        var constructors = typeof(AuthController).GetConstructors();

        constructors.Length.Should().Be(1);
    }
}
