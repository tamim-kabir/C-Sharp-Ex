﻿
using System;
using System.Collections.Generic;
using System.Text;

namespace Packt.Shared
{
     public class GenericThigs<T> where T : IComparable
    {
        public T Data = default(T);

        public string Process(T input)
        {
            if(Data.CompareTo(input)==0)
            {
                return "Data and input are the same";
            }
            else
            {
                return "Data and input are not same";
            }
        }
    }
}
