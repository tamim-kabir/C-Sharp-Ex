using System;
using System.Collections.Generic;
using System.Text;

namespace Packt.Shared
{
    public partial class Person
    {
        public string Origine
        {
            get { return $"{name} was born on {HomePlanet}"; }
        }
        public string Greeting => $"{name} says Hello!!";
        public int Age => DateTime.Today.Year - birthOfDate.Year;
    }
}
