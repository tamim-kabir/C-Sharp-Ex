using System;
using Packt.Shared;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        { var harry = new Person { Name = "Harry" };
            var marry = new Person { Name = "Marry" };
            var jill = new Person { Name = "Jill" };

            var baby1 = marry.ProcreateWith(harry);

            var baby2 = Person.Procreate(harry, jill);

            WriteLine($"{harry.Name} has {harry.Children.Count} children..");
            WriteLine($"{marry.Name} has {marry.Children.Count} children..");
            WriteLine($"{jill.Name} has {jill.Children.Count} children..\n");

            WriteLine(format: "{0}'s first childen name \"{1}\" ", arg0: harry.Name, arg1: harry.Children[0].Name);
           
            foreach(people in Person)
            {

            }
            /*
            WriteLine($"5! is {Person.Facturial(5)}");

            var p1 = new Person();

            var d = new Person.DelegateWithThaMachingSignature(p1.MethosdIWantToCall);
            var ans = d("foood");
            WriteLine(ans); */
        }
        void person()
        {
            var harry = new Person { Name = "Harry" };
            var marry = new Person { Name = "Marry" };
            var jill = new Person { Name = "Jill" };

            var baby1 = marry.ProcreateWith(harry);

            var baby2 = Person.Procreate(harry, jill);

            WriteLine($"{harry.Name} has {harry.Children.Count} children..");
            WriteLine($"{marry.Name} has {marry.Children.Count} children..");
            WriteLine($"{jill.Name} has {jill.Children.Count} children..\n");

            WriteLine(format: "{0}'s first childen name \"{1}\" ", arg0: harry.Name, arg1: harry.Children[0].Name);
        }
    }
}
