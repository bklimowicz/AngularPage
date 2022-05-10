using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Libraries.AuthService.Helpers
{
    public class JwtService : IJwtService
    {
        private string SecureKey = "pralinka123tofek-kociaczki";

        public string Generate(int id)
        {
            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecureKey));
            var credentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);
            var payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Today.AddDays(1));
            var securityToken = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}

