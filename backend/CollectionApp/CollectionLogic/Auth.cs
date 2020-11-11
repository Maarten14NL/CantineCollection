using CollectionEntities;
using CollectionFactory;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionLogic
{
    public class Auth
    {
        
        private readonly IUser _UserDal = UserFactory.GetUser();
        private readonly IAuth _AuthDal = AuthFactory.GetAuth();
        private AuthDto auth;

        private bool _loggedIn = false;
        public void Login()
        {
            auth = _AuthDal.Login().Result;
            _loggedIn = true;
        }

        public void LogOut()
        {
            auth = null;
        }

        public Boolean IsLoggedIn()
        {
            return _loggedIn;
        }

        public UserDTO GetLoggedInUser()
        {
            this.Login();
            var tokenHandler = new JwtSecurityTokenHandler();
            var paresedToken = tokenHandler.ReadJwtToken(auth.auth_token);

            UserDTO user = new UserDTO()
            {
                Id = Convert.ToInt32(paresedToken.Claims.Where(c => c.Type == "id").FirstOrDefault().Value),
                FirstName = paresedToken.Claims.Where(c => c.Type == "firstName").FirstOrDefault().Value,
                LastName = paresedToken.Claims.Where(c => c.Type == "lastName").FirstOrDefault().Value,
                Email = paresedToken.Claims.Where(c => c.Type == "email").FirstOrDefault().Value,
                ProfilePicture = paresedToken.Claims.Where(c => c.Type == "profilePicture").FirstOrDefault().Value,

            };
            return user;
        }
    }
}
