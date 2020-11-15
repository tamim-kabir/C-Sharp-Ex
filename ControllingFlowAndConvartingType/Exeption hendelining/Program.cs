using System;

namespace Exeption_hendelining
{
    class Program
    {
        static void Main(string[] args)
        {
            unchecked
            {
                int x = int.MaxValue - 1;
                Console.WriteLine(x);
                x++;
                Console.WriteLine(x);
                x++;
                Console.WriteLine(x);
                x++;
                Console.WriteLine(x);
            }            
            Console.WriteLine("end Exeption");
        }
    }
}
