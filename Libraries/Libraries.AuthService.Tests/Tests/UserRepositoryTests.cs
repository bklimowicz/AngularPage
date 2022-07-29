using FluentAssertions;
using Xunit;
using System.Linq;
using Libraries.SqlDBConnector.Data;
using Moq;
using Libraries.SqlDBConnector.Models;
using System.Collections.Generic;
using Libraries.AuthService.Tests.Fixtures;

namespace Libraries.AuthService.Tests
{
    public class UserRepositoryTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;

        private readonly IUserRepository _userRepository;

        private static IEnumerable<object[]> TestUser()
        {
            var sampleDataList = new List<User>
            {
                new User()
                {
                    Id = 1,
                    Email = "test@test.com",
                    Name = "test",
                    Password = "test"
                }
            };

            var retVal = new List<object[]>();
            foreach (var item in sampleDataList)
            {
                retVal.Add(new object[] { item });
            }
            return retVal;
        }

        public UserRepositoryTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
            var context = fixture.CreateContext();
            this._userRepository = new UserRepository(context);
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
        public void GivenUserAddsToDatabase(User user)
        {
            // var result = _userRepository.Create(user);

            // result.Should().Be(user);
        }
    }
}