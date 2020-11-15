using Check.Valid;
using System;

namespace assamblesandProj
{
    class Program
    {
        static void Main(string[] args)
        {
            string pas = Console.ReadLine();
            Console.WriteLine($"{pas} is a valid password {pas.IsValidPassword()}");
        }
    }
}
