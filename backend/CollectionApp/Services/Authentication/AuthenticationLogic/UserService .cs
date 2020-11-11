using AuthenticationLogic.models;
using AuthenticationLogic.helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace AuthenticationLogic
{
    public interface IUserService
    {
        models.SecurityToken Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Maarten", LastName = "Jakobs", Email = "maarten.jakobs@gmail.com", Password = "sonu@123", ProfilePicture = "maarten.JPG" },
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public models.SecurityToken Authenticate(string email, string password)
        {
            var user = _users.SingleOrDefault(x => x.Email == email && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim("firstName", user.FirstName),
                    new Claim("lastName", user.LastName),
                    new Claim("email", user.Email),
                    new Claim("profilePicture", user.ProfilePicture)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key), Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtSecurityToken = tokenHandler.WriteToken(token);

            return new models.SecurityToken() { Auth_token = jwtSecurityToken };
        }
    }
}
