using Libraries.AuthService.Controllers;
using Libraries.AuthService.Services;
using FluentAssertions;
using Xunit;
using System;
using System.Linq;
using Libraries.AuthService.Data;
using Moq;
using Libraries.AuthService.Models;

namespace Libraries.AuthService.Tests
{
    public class UserServiceTests
    {
        private readonly UserAuthService _userAuthService;

        public UserServiceTests()
        {
            this._userAuthService = new UserAuthService();
        }

        [Fact]
        public void UserAuthServiceExists()
        {
            this._userAuthService.Should().NotBeNull();
        }
    }
}

