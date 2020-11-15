using System;
using static System.Console;
using System.Globalization;

namespace Internationalization
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo globalization = CultureInfo.CurrentCulture;
            CultureInfo localization = CultureInfo.CurrentUICulture;

            WriteLine($"The current Globalization culture is {globalization.Name}: {globalization.DisplayName}");
            WriteLine($"The current localization culture Is {localization.Name}: {localization.DisplayName}\n");

            WriteLine("en-US: English (United States)");
            WriteLine("da-DK: Danish (Denmark)");
            WriteLine("fr-CA: French (Canada)");
            Write("Enter the ISO culture code : ");
            string newCulture = ReadLine();

            if(!string.IsNullOrEmpty(newCulture))
            {
                var ci = new CultureInfo(newCulture);
                CultureInfo.CurrentCulture = ci;
                CultureInfo.CurrentUICulture = ci;
            }
            WriteLine();
            Write("Enter your Name:");
            string name = ReadLine();
            Write("Enter your date of birth:");
            string dob = ReadLine();
            Write("Enter your salary");
            string salary = ReadLine();

            DateTime date = DateTime.Parse(dob);
            int minutes = (int)DateTime.Today.Subtract(date).TotalMinutes;
            decimal earns = decimal.Parse(salary);
                        
            WriteLine($"{name} was born on a {date:dddd}, is {minutes:N0} minutes old, and earn {earns:C}");
        }
    }
}
