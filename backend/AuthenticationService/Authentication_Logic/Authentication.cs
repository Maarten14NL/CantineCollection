using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Authentication_Logic
{
    public class Authentication
    {

        public string Hash(string ToHash)
        {
            // First we need to convert the string into bytes,
            // which means using a text encoder.
            Encoder enc = Encoding.ASCII.GetEncoder();

            // Create a buffer large enough to hold the string
            byte[] data = new byte[ToHash.Length];
            enc.GetBytes(ToHash.ToCharArray(), 0, ToHash.Length, data, 0, true);

            // This is one implementation of the abstract class MD5.
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);

            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }
        private bool TestHash(string HashStr, string UserName, int minutes, string ServiceName)
        {
            string Pwd, ToHash;
            string sResult, sResultT, sResultToken;
            try
            {
                // JUST FOR TEST: the password is hard-coded:
                Pwd = "SeCrEt";

                DateTime dt = DateTime.Now;
                System.TimeSpan minute = new System.TimeSpan(0, 0, minutes, 0, 0);
                dt = dt - minute;
                //before hashing we have:
                //USERNAME|PassWord|YYYYMMDD|HHMM
                ToHash = UserName.ToUpper() + "|" + Pwd + "|" + dt.ToString("yyyyMMdd") +
                                                     "|" + dt.ToString("HHmm");
                sResult = Hash(ToHash);
                //TokenWeGotBefore
                ToHash = dt.ToString("yyyyMMdd") + "|" + dt.ToString("HHmm");
                sResultToken = Hash(ToHash);
                //USERNAME|PassWord|TokenWeGotBefore
                ToHash = UserName.ToUpper() + "|" + Pwd + "|" + sResultToken;
                sResultT = Hash(ToHash);

                if ((sResult == HashStr) || (sResultT == HashStr))
                    return true;
                else
                    if (minutes == 0) // allowed max 2 minutes - 1
                                      // second to call web service
                    return TestHash(HashStr, UserName, 1, ServiceName);
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public string GetToken()
        {
            string ToHash, sResult;
            DateTime dt = DateTime.Now;
            ToHash = dt.ToString("yyyyMMdd") + "|" + dt.ToString("HHmm");
            sResult = Hash(ToHash);
            return sResult;
        }
        public string UseService(string Key, string ServiceName)
        {
            string[] HashArray;
            string UserName, level;

            // Key string: HASH|User|OptionalData
            HashArray = Key.Split('|');
            level = "-1";    //default level
            UserName = "";

            if (TestHash(HashArray[0], HashArray[1], 0, ServiceName))
            {
                try
                {
                    UserName = HashArray[1];
                    // JUST FOR TEST: the User authentication level is hard-coded
                    // but may/should be retrieved from a DataBase
                    switch (UserName)
                    {
                        case "MyUserName":
                            level = "1";
                            break;
                        case "OtherUser":
                            level = "2";
                            break;
                        default:
                            level = "-1";
                            break;
                    }
                    if (level == "1") return "YOU ARE AUTHORIZED";
                }
                catch (Exception exc)
                {
                    return "Authentication failure: " + exc.ToString();
                }
            }
            return "Authentication failure";
        }

        public string Login(string Key, string ServiceName)
        {
            string[] HashArray;
            string UserName, Password;

            // Key string: HASH|User|OptionalData
            HashArray = Key.Split('|');
            UserName = HashArray[1];


            string salt = "dsfsdfsdfdsfsdfsf";
            string password = "test";

            Password = HashPassword(salt, password);

            if (TestHash(HashArray[0], UserName, 0, ServiceName))
            {
                try
                {
                   
                }
                catch (Exception exc)
                {
                    return "Authentication failure: " + exc.ToString();
                }
            }
            return "Authentication failure";
        }


        const string alphanumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        private static string GetSalt(int saltSize)
        {
            Random r = new Random();
            StringBuilder strB = new StringBuilder("");

            while ((saltSize--) > 0)
                strB.Append(alphanumeric[(int)(r.NextDouble() * alphanumeric.Length)]);
            return strB.ToString();
        }

        private static string HashPassword(string salt, string password)
        {
            string mergedPass = string.Concat(salt, password);
            return EncryptUsingMD5(mergedPass);
        }

        private static string EncryptUsingMD5(string inputStr)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(inputStr));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                    sBuilder.Append(data[i].ToString("x2"));

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }
    }
}
