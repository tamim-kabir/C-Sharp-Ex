using System;
using static System.Console;

namespace Function
{
    class Program
    {
        static void TimesTable(byte n)
        {
            WriteLine($"This is the {n} Times tabel");
            for(int i =1; i <= 10; i++)
            {
                WriteLine($"{i} x {n} = {i * n}");
            }
            WriteLine();
        }
        static void Runtimes()
        {
            bool isNumber;
            do
            {
                Write("Enter Number between 0 to 255 : ");
                isNumber = byte.TryParse(ReadLine(), out byte n);

                if(isNumber)
                {
                    TimesTable(n);
                }
                else
                {
                    WriteLine("You did not Enter valid number");
                }
            } while (isNumber);
        }
        
        static void Main(string[] args)
        {
            Runtimes();
        }
    }
}
