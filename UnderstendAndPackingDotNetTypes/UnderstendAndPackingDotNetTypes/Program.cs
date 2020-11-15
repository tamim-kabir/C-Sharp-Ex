using Check.Valid;
using System;

namespace Check.Vali
{
    class Program
    {
        static void Main(string[] args)
        {
            var pass = Console.ReadLine();

            Console.WriteLine($"The Password is : {pass.IsValidPassword()}");
        }
    }
}
