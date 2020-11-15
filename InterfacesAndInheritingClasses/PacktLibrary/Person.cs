using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.Shared
{
    public class Person
    {
        //fields
        public string Name;
        public DateTime DateOfbirth;
        public List<Person> Children = new List<Person>();

        //methods
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfbirth: dddd}");
        }

        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };
            p1.Children.Add(baby);
            p2.Children.Add(baby);

            return baby;
        }
        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }

        public static int Facturial(int number)
        {
            if(number < 0)
            {
                throw new ArgumentException($"{nameof(number)} can't be less zero");
            }
            return localFacturial(number);
            int localFacturial(int localNumber)
            {
                if (localNumber < 1) return 1;

                return localNumber * localFacturial(localNumber - 1);
            }
        }
        public delegate int DelegateWithThaMachingSignature(string s);
        public int MethosdIWantToCall(string input)
        {
            return input.Length;
        }
    }
    
}
