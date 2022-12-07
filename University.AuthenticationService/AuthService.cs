using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using University.AuthenticationService.Contracts;
using University.AuthenticationService.Models;
using University.DAL.Entities;

namespace University.AuthenticationService
{
    public class AuthService : IAuthService
    {
        private readonly JwtSetting _jwtSetting;
        private readonly List<User> _users;

        public AuthService(IOptions<JwtSetting> jwtSetting)
        {
            _users = new List<User>
            {
                new User
                {
                    Username="Jamal",
                    Password="123",
                    Email="jamal@code.edu.az"
                },
                new User
                {
                    Username="Fexrin",
                    Password="123",
                    Email="fexrin@code.edu.az"
                },
            };

            _jwtSetting = jwtSetting.Value;
        }

        public string GetToken(TokenRequestModel model)
        {
            var user = _users.Find(x => x.Username == model.Username);

            if (user == null) throw new Exception();

            var token = CreateJwtToken(user);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken CreateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("roles", "Admin")
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSetting.Issuer,
                audience: _jwtSetting.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSetting.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
