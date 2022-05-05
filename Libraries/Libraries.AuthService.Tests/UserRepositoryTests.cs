using Libraries.AuthService.Controllers;
using Libraries.AuthService.Services;
using FluentAssertions;
using Xunit;
using System;
using System.Linq;
using Libraries.AuthService.Data;
using Moq;
using Libraries.AuthService.Models;
using System.Collections;
using System.Collections.Generic;

namespace Libraries.AuthService.Tests
{
    public class UserRepositoryTests
    {
        private readonly IUserRepository _userRepository;

        private static IEnumerable<object[]> TestUser()
        {
            var sampleDataList = new List<User>
            {
                new User()
                {
                    Email = "testemail@gmail.com",
                    Name = "TestUser",
                    Password = "TestPassword"
                }
            };

            var retVal = new List<object[]>();
            foreach (var item in sampleDataList)
            {
                retVal.Add(new object[] { item });
            }
            return retVal;
        }

        public UserRepositoryTests()
        {
            var mockContext = new Mock<IUserContext>();

            this._userRepository = new UserRepository(mockContext.Object);
        }

        [Fact]
        public void UserRepositoryHasUserContextDependency()
        {
            var constructor = typeof(UserRepository).GetConstructors()[0];
            var parameters = constructor.GetParameters().ToList();

            var result = parameters.Any(p => typeof(IUserContext).IsAssignableFrom(p.ParameterType));

            result.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestUser))]
        public void GivenUserAddUserToDatabase(User user)
        {
            var returnedUser = this._userRepository.Create(user);

            returnedUser.Should().NotBeNull();
        }
    }
}