using System;
using System.Text;

namespace WorkingWithEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            ByteArray();
        }
        static void ByteArray()
        {
            Console.WriteLine("Encoding");
            Console.WriteLine("[1] ASCII");
            Console.WriteLine("[2] UFT-7");
            Console.WriteLine("[3] UFT-8");
            Console.WriteLine("[4] UFT-16");
            Console.WriteLine("[5] UFT-32");
            Console.Write("Press a number to chose encoding: ");
            ConsoleKey number = Console.ReadKey(intercept:false).Key;
            Console.WriteLine();

            Encoding encoder = number switch
            {
                ConsoleKey.D1 => Encoding.ASCII,
                ConsoleKey.D2 => Encoding.UTF7,
                ConsoleKey.D3 => Encoding.UTF8,
                ConsoleKey.D4 => Encoding.Unicode,
                ConsoleKey.D5 => Encoding.UTF32,
                _             => Encoding.Default
            };

            Console.Write("Enter a string: ");
            string massage = Console.ReadLine();

            byte[] encoded = encoder.GetBytes(massage);

            Console.WriteLine("Byte     Hex   Char");
            foreach(var b in encoded)
            {
                Console.WriteLine($"{b,4} | {b,4:X} | {(char)b,4}");
                Console.WriteLine("--------------------");
            }
            string decoded = encoder.GetString(encoded);
            Console.WriteLine(decoded);
        }
    }
}
