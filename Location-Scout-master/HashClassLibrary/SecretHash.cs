using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HashClassLibrary
{
    public class SecretHash
    {
        public String getHashValue(String input)
        {
            String str = new SecretHash().secretHashMethod(input);
            String output = String.Copy(str);
            return output;
        }
        private String secretHashMethod(String input)
        {
            UnicodeEncoding Uce = new UnicodeEncoding();
            byte[] inputBytes = Uce.GetBytes(input);
            SHA1Managed SHhash = new SHA1Managed();
            byte[] HashValue1 = SHhash.ComputeHash(inputBytes);
            String str = Convert.ToBase64String(HashValue1);
            return str;
        }
    }
}
