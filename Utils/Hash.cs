using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChatQJW.Core.Utils
{
    public class Hash
    {
        public string HashKey(long x, long y, long z)
        {
            string hash = string.Empty;

            if (x > y)
                hash = x.ToString() + y.ToString() + z.ToString();
            else
                hash = y.ToString() + x.ToString() + z.ToString();

            return SHA512(hash);
        }

        public string SHA512(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA512Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

    }
}
