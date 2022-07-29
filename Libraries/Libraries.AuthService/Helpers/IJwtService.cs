using System.IdentityModel.Tokens.Jwt;

namespace Libraries.AuthService.Helpers
{
    public interface IJwtService
    {
        string Generate(int id);
        JwtSecurityToken Verify(string token);
    }
}