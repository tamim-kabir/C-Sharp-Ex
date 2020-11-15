using System;
using System.Threading.Tasks;

namespace WritingDebuggingAndTestingFunction
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var complexObject = new
            {
                FirstName = "Peter",
                BirthDate = new DateTime(year: 1972, month: 12, day:25),
                Friends = new[] {"Amir", "kadir", "alfaz"}
            };
            Console.WriteLine($"Dumping{nameof(complexObject)} to sharpPad");
            await complexObject.Dump();
        }

    }
}
