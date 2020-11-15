using System;
using static System.Console;
using Packt.Shared;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sam = new Person
            {
                name = "Sam stoe",
                birthOfDate = new DateTime(1972, 1, 27)
            };
            WriteLine(sam.Origine);
            WriteLine(sam.Greeting);
            WriteLine(sam.Age);
        }
        

        void BankAccountclass()
        {
            BankAccount.InterestRate = 0.012M;
            var jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Ballance = 2400;

            WriteLine(format: "{0} earned {1:C} interest", arg0: jonesAccount.AccountName, arg1: jonesAccount.Ballance * BankAccount.InterestRate);

            var gerrierAccount = new BankAccount();
            gerrierAccount.AccountName = "Ms. Gerrier";
            gerrierAccount.Ballance = 98;

            WriteLine(format: "{0} earned {1:C} interest", arg0: gerrierAccount.AccountName, arg1: gerrierAccount.Ballance * BankAccount.InterestRate);

        }

        void Papp()
        {
            var bob = new Person();
            bob.name = "Bob smith";
            bob.birthOfDate = new DateTime(1995, 12, 23);
            WriteLine(format: "{0} was born in {1:dddd, d MMMM yyyy}", arg0: bob.name, arg1: bob.birthOfDate);

            bob.Children.Add(new Person { name = "Alfred" });
            bob.Children.Add(new Person { name = "Zoe" });

            WriteLine($"Has {bob.Children.Count} children!!");

            for (int child = 0; child < bob.Children.Count; child++)
            {
                WriteLine(bob.Children[child].name);
            }
            var alice = new Person
            {
                name = "Alice Jonson",
                birthOfDate = new DateTime(1998, 3, 7)
            };
            WriteLine(format: "{0} was born in {1: dd MMMM yyyy}", arg0: alice.name, arg1: alice.birthOfDate);
        }
    }
}
