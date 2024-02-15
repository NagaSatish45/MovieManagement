using Microsoft.IdentityModel.Tokens;
using MoviesAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviesAPI.Repo
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        Dictionary<string, string> UsersRecords = new Dictionary<string, string>()
        {
            { "user1","password1"},
            { "user2","password2"},
            { "user3","password3"}
        };
        private readonly IConfiguration configuration;

        public JWTManagerRepository(IConfiguration iconfiguration)
        {
            this.configuration = iconfiguration;
        }
        public string Authentication(LoginModel login)
        {
            if (login != null && !UsersRecords.Any(x => x.Key == login.Username && x.Value == login.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name,login.Username)
             }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
