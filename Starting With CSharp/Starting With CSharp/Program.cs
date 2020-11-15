using System;
using static System.Console;

namespace Starting_With_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Press Enter any Key: ");
            ConsoleKeyInfo key = ReadKey();
            WriteLine("\n\nKey: {0}, char: {1}, Modifier: {2}",
                arg0: key.Key,
                arg1: key.KeyChar,
                arg2: key.Modifiers
                );
        }
    }
}
