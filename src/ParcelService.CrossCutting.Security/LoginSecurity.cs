using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ParcelService.CrossCutting.Security
{
    public class LoginSecurity
    {
        private const string _SecurityKey = "";

        public static string defaultKey
        {
            get
            {
                System.Configuration.AppSettingsReader s = new System.Configuration.AppSettingsReader();
                return s.GetValue("defaultKey", typeof(string)).ToString();
            }
        }

        public static string Encrypt(string strInput)
        {
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            MemoryStream cipherText = new MemoryStream();
            CryptoStream encrypted;
            string result = string.Empty;

            try
            {
                byte[] text = unicodeEncoding.GetBytes(HttpUtility.HtmlEncode(strInput));
                byte[] salt = new byte[0];
                PasswordDeriveBytes passwordDerive = new PasswordDeriveBytes(defaultKey, salt);
                byte[] derivedKey = passwordDerive.GetBytes(24);
                provider.Key = derivedKey;
                provider.IV = passwordDerive.GetBytes(8);

                encrypted = new CryptoStream(cipherText, provider.CreateEncryptor(), CryptoStreamMode.Write);
                encrypted.Write(text, 0, strInput.Length);
                encrypted.FlushFinalBlock();

                result = Convert.ToBase64String(cipherText.ToArray());

                encrypted.Close();
                encrypted.Dispose();
                cipherText.Close();

                return result;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (cipherText != null)
                    cipherText.Dispose();

                provider.Clear();
            }
        }

        public static string Decrypt(string strCipher)
        {
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            CryptoStream decrypted;
            MemoryStream plainText = new MemoryStream();
            MemoryStream cipherText;
            string result = string.Empty;

            try
            {
                byte[] byteCipherText = Convert.FromBase64String(strCipher);
                cipherText = new MemoryStream(byteCipherText);
                byte[] salt = new byte[0];
                PasswordDeriveBytes passwordDerive = new PasswordDeriveBytes(defaultKey, salt);
                byte[] derivedKey = passwordDerive.GetBytes(24);
                provider.Key = derivedKey;
                provider.IV = passwordDerive.GetBytes(8);

                decrypted = new CryptoStream(cipherText, provider.CreateDecryptor(), CryptoStreamMode.Read);

                StreamWriter writer = new StreamWriter(plainText);
                StreamReader reader = new StreamReader(decrypted);
                writer.Write(reader.ReadToEnd());
                writer.Flush();

                result = unicodeEncoding.GetString(plainText.ToArray());

                decrypted.Clear();
                decrypted.Dispose();

                cipherText.Close();
                cipherText.Dispose();

                return HttpUtility.HtmlDecode(result);
            }
            catch
            {
                return null;
            }
            finally
            {
                provider.Clear();
                plainText.Close();
                plainText.Dispose();
            }
        }

        public static string ByteArrayToHexString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }
    }
}