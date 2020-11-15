using System;
using System.IO;
using static System.Console;

namespace Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter + for addtion\n");
            WriteLine("Enter - for subtruction\n");
            WriteLine("Enter * for multiplication\n");
            WriteLine("Enter / for divition\n");

            ConsoleKeyInfo key= ReadKey();
            char s = key.KeyChar;
            decimal a = 2, b = 3;
            
            string d = s switch
            {
                '+' => Convert.ToString( a + b),
                '-' => Convert.ToString( a - b),
                '*' => Convert.ToString( a * b),
                '/' => Convert.ToString( a / b),
                _   =>"You enter worng arithmatic symble"
            };
        }
    }
}
