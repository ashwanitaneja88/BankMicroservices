using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthAPI
{
    public class JwtTokenService
    {
        private readonly List<User> _users = new()
    {
        new("admin", "aDm1n", "Administrator", new[] {"bank.write"}),
        new("user01", "u$3r01", "User", new[] {"bank.read"})
    };

        public AuthenticationToken? GenerateAuthToken(LoginModel loginModel)
        {
            var user = _users.FirstOrDefault(u => u.Username == loginModel.Username
                                               && u.Password == loginModel.Password);

            if (user is null)
            {
                return null;
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtExtensions.SecurityKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expirationTimeStamp = DateTime.Now.AddMinutes(5);

            var claims = new List<Claim>
        {
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Name, user.Username),
            new Claim("role", user.Role),
            new Claim("scope", string.Join(" ", user.Scope))
        };

            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:7173",
                claims: claims,
                expires: expirationTimeStamp,
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new AuthenticationToken { Name = tokenString, Value = expirationTimeStamp.Subtract(DateTime.Now).TotalSeconds.ToString() };
        }
    }
}
