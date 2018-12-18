using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WebChatQJW.Core.Utils
{
    public class Encrypt
    {
        public string EncryptData(string mensagem, long x, long y, long c)
        {
            var ENCRYPTKEY = new Hash().HashKey(x, y, c);

            byte[] clearBytes = Encoding.Unicode.GetBytes(mensagem);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(ENCRYPTKEY, new byte[] {
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                    });

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    mensagem = Convert.ToBase64String(ms.ToArray());
                }
            }
            return mensagem;
        }
    }
}
