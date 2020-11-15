using System;
using System.Collections.Generic;

namespace Packt.Shared
{
    public partial class Person : Object
    {
        public string name;
        public readonly string HomePlanet = "Earth";
        public DateTime birthOfDate;
        public List<Person> Children = new List<Person>();
        public WonderOfTheAncientWorld favariteAncientWonder;
    }
   
}
