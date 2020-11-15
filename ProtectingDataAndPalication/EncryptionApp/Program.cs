using System;
using System.Security.Cryptography;
using CryptographyLib;
using static System.Console;

namespace EncryptionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //testCryptoGraphy();
            testloging();
        }

        static void testCryptoGraphy()
        {
            Write("Enter a massage :");
            string massage = ReadLine();
            Write("Enter a password :");
            string password = ReadLine();
            string cryptoText = Protector.Encryption(massage, password);
            WriteLine($"Encrypted text :{cryptoText}");
            Write("Enter a password :");
            string password2 = ReadLine();

            try
            {
                string clearText = Protector.Decrypt(cryptoText, password2);
                WriteLine($"Decrypted text: {clearText}");
            }
            catch(CryptographicException cex)
            {
                WriteLine($"You Entered a wrong password! \nMore details: {cex.Message}");
            }
            catch(Exception ex)
            {
                WriteLine($"Non-Cryptographic Exception {ex.GetType().Name}, {ex.Message}");
            }
        }
        static void testloging()
        {
            WriteLine("Register Name and Password: ");
            var alice = Protector2.Register("Alice", "Pa$$word");
            WriteLine($"Name: {alice.Name}");
            WriteLine($"Salt: {alice.Salt}");
            WriteLine($"Password salted and hashed: {alice.SaltedHashedPassword}");
            WriteLine();

            Write("new user regsister: ");
            string userName = ReadLine();
            Write($"Enter  password for this {userName}: ");
            string password = ReadLine();
            var user = Protector2.Register(userName, password);
            WriteLine($"Name: {user.Name}");
            WriteLine($"Name: {user.Salt}");
            WriteLine($"Password salted and hashed: {user.SaltedHashedPassword}");
            WriteLine();

            bool c = false;
            while(!c)
            {
                Write("Enter user name to login: ");
                string username=ReadLine();
                Write("Enter password for login: ");
                string pass = ReadLine();
                c = Protector2.CheckPassword(username, pass);
                if(c)
                {
                    WriteLine($"Currect! {username} has been login");
                }
                else
                {
                    WriteLine("Invalid username or password");
                }
            }
        }
    }
}
