using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Xml.Linq;
using static System.Convert;

namespace CryptographyLib
{
    public static class Protector
    {
        //Salt must be greater then 8 bytes
        private static byte [] Salt = Encoding.Unicode.GetBytes("7BANANA");

        //Itearation must be at least 1000
        private static readonly int i = 2000;

        public static string Encryption(string plainText, string password)
        {
            byte [] encryptedBytes;
            byte [] plainBytes = Encoding.Unicode.GetBytes(plainText);
            Aes aes = Aes.Create();
            Rfc2898DeriveBytes pbkdf = new Rfc2898DeriveBytes(password, Salt, i);
            aes.Key = pbkdf.GetBytes(32);
            aes.IV = pbkdf.GetBytes(16);
            using(MemoryStream ms = new MemoryStream())
            {
                using(CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plainBytes, 0, plainBytes.Length);
                }
                encryptedBytes = ms.ToArray();
            }
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string cryptoText, string password)
        {
            byte [] palinBytes;
            byte [] cryptoBytes = Convert.FromBase64String(cryptoText);
            Aes aes = Aes.Create();
            Rfc2898DeriveBytes pbkdf = new Rfc2898DeriveBytes(password, Salt, i);

            aes.Key = pbkdf.GetBytes(32);
            aes.IV = pbkdf.GetBytes(16);

            using(MemoryStream ms = new MemoryStream())
            {
                using(CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cryptoBytes, 0, cryptoBytes.Length);
                }
                palinBytes = ms.ToArray();
            }
            return Encoding.Unicode.GetString(palinBytes);
        }
    }
    public class Protector2
    {
        private static Dictionary<string, User> Users = new Dictionary<string, User>();
        
        public static User Register(string userNmae, string password)
        {
            //genetate the rendom salt
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            var saltText = Convert.ToBase64String(saltBytes);

            var saltedhashedPassword = SaltAndHashPassword(password, saltText);
            var user = new User
            {
                Name = userNmae,
                Salt = saltText,
                SaltedHashedPassword = saltedhashedPassword
            };
            Users.Add(user.Name, user);
            return user;
        }
        public static bool CheckPassword(string userName, string password)
        {
            if(!Users.ContainsKey(userName))
            {
                return false;
            }
            var user = Users[userName];
            var saltedhashedPassword = SaltAndHashPassword(password, user.Salt);
            return (saltedhashedPassword == user.SaltedHashedPassword);
        }
        public static string SaltAndHashPassword(string password, string salt)
        {
            var sha = SHA256.Create();
            var saltedPassword = password + salt;

            return Convert.ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
        }
    }
}
