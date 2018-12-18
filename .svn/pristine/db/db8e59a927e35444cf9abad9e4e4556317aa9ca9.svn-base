using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebChatQJW.Core.Utils
{
    public class Decrypt
    {
        public string DecryptData(dynamic mensagem, long x, long y, long c)
        {
            var ENCRYPTKEY = new Hash().HashKey(x, y, c);

            mensagem = mensagem.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(mensagem);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(ENCRYPTKEY, new byte[] {
                 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    mensagem = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return mensagem;
        }
    }
}
