using CollectionEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAuth
{
    public class AuthController : IAuth
    {
        private const string RequestUri = "https://localhost:44380/api/product";
        private static readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:44365")
        };

        public async Task<AuthDto> Login()
        {
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json")
            //);

            HttpResponseMessage response = await client.GetAsync("/api/user");
            response.EnsureSuccessStatusCode();
            string result = response.Content.ReadAsStringAsync().Result;
            AuthDto accessToken = JsonConvert.DeserializeObject<AuthDto>(result);

            var tokenHandler = new JwtSecurityTokenHandler();
            var paresedToken = tokenHandler.ReadJwtToken(accessToken.auth_token);

            return accessToken;
        }
    }
}
