using System;
using Check.Valid;

namespace AssambileAndmanage
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();

            Console.WriteLine($"{pass} is Valid?:{pass.IsValidEmail()}");
        }
    }
}
