﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Packt.Shared
{
    public class Think
    {
        public object Data = default(object);

        public string Process(object input)
        {
            if(Data == input)
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
