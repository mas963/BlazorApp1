using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Utils
{
    public class PasswordEncrypter
    {
        public static string Encrypt(string password)
        {
            // kendi algoritmamızı kullanabiliriz
            // ben base64 olarak kullanıyorum

            var plainTextBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
