using Libraries.AuthService.Helpers;
using Libraries.AuthService.Models;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;

namespace Libraries.AuthService.Tests
{
    public class JwtServiceTests
    {
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

        private readonly IJwtService _jwtService;
        public JwtServiceTests()
        {
            _jwtService = new JwtService();
        }

        [Theory]
        [MemberData(nameof(TestUser))]
        public void GivenUserInfoThenReturnToken(User user)
        {
            // Arrange

            // Act
            var result = _jwtService.Generate(user.Id);

            // Assert
            result.Should().Be("eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2NTI5OTc2MDAsImlzcyI6IjEifQ.TO-8hAVJUam1OdyzMIykqDLFla0-5raz-KEuyxyr48s");
        }
    }
}