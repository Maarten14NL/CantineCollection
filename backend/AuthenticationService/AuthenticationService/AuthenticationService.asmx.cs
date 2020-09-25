using Authentication_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;

namespace AuthenticationService
{
    /// <summary>
    /// Summary description for AuthenticationService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AuthenticationService : System.Web.Services.WebService
    {
        private Authentication auth = new Authentication();
            

        [WebMethod]
        public string GetToken()
        {
            return auth.GetToken();
        }

        [WebMethod]
        public string UseService(string Key, string ServiceName)
        {
            return auth.UseService(Key, ServiceName);
        }

        [WebMethod]
        public string Test(string UserName, string Password, string ServiceName)
        {
            string Token;
            string Key, ToHash;
            Token = this.GetToken();
            ToHash = UserName.ToUpper() + "|" + Password + "|" + Token;
            Key = auth.Hash(ToHash) + "|" + UserName;

            return this.UseService(Key, ServiceName);
        }
    }
}
