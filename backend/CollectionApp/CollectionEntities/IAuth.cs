using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionEntities
{
    public class AuthDto
    {
        public string auth_token { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
    public interface IAuth
    {
        Task<AuthDto> Login();
    }
}
