using CollectionEntities;
using CollectionFactory;
using CollectionLogic.Entities;
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
        private static AuthDto auth;

        private bool _loggedIn = false;
        public UserEntitiy Login()
        {
            if (_AuthDal.Login().Result != null)
            {
                auth = _AuthDal.Login().Result;
                return new UserEntitiy().UserDTOToUser(GetLoggedInUser());
            }
            return null;
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
            var tokenHandler = new JwtSecurityTokenHandler();
            if (auth != null) { 
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
            return null;
        
        }
    }
}
