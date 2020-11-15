using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using static System.Console;

namespace Advace_C_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            char[] s = str.ToCharArray();
            int count, temp=0, temp2 = 0, t=0;
            for (int i = 0; i < s.Length; i++)
            {
                count = 0;
                for (int j = 0; j < s.Length; j++)
                {
                    if (s[i] == s[j])
                        count++;                    
                }
                //Console.WriteLine(s[i]);
                if (count > t)
                {
                    temp = Convert.ToInt32(s[i].ToString());
                    t = count;
                }
                else if (count == t )
                {
                    temp2 = Convert.ToInt32(s[i].ToString());
                }
                
            }
            if (temp < temp2)
                Console.WriteLine(temp);
            else
                Console.WriteLine(temp2);
        }

        //void Timezone.info();

        unsafe void BlueFilter(int[,] bitmap)
        {
            fixed (int* b = bitmap)
            {
                int* p = b;
                for (int i = 0; i < bitmap.Length; i++)
                {
                    *p++ &= 0xFF;
                }
            }
        }

        static void StandardEventPattern()
        {
            Stack stack = new Stack("Thump");
            stack.Price = 27.6M;
            stack.priceChange += Stock_PriceChanged;
            stack.Price = 50.78M;
        }
        static void Stock_PriceChanged(object sender, PriceChangeEventArg e)
        {
            if ((e.newPrice - e.lastPrice) / e.lastPrice > 0.1M)
                WriteLine("Alart 10% stock price are Incrise!!!");
            else
                WriteLine("Stock Price Are Not Incrise");
        }

        static void transform()
        {
            int[] value = { 1, 2, 3 };
            Unit.Transform(value, Unit.Square);
            foreach (int i in value)
                Write(i + " ");
        }
    }

    public class Timezone
    {
        public static void TimeDeligth()
        {
            TimeZone zone = TimeZone.CurrentTimeZone;
            WriteLine(zone.StandardName);
            WriteLine(zone.DaylightName);

            DateTime dt1 = new DateTime(2020, 1, 1);
            DateTime dt2 = new DateTime(2020, 6, 1);

            WriteLine(zone.IsDaylightSavingTime(dt1));
            WriteLine(zone.IsDaylightSavingTime(dt2));
            WriteLine(zone.GetUtcOffset(dt1));
            WriteLine(zone.GetUtcOffset(dt2));
        }
        public static void info()
        {
            TimeZoneInfo zi = TimeZoneInfo.FindSystemTimeZoneById("W. Australia Standard Time");
            WriteLine(zi.Id);
            WriteLine(zi.DisplayName);
            WriteLine(zi.BaseUtcOffset);
            WriteLine(zi.SupportsDaylightSavingTime);

            foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
                WriteLine(z.Id);
        }
    }


    public class Pragma
    {
        public static void ParamWriting()
        {
#pragma warning disable 414
            string massage = "hello";
            Write(massage);
#pragma warning restore 414
            Write("its okey");
        }
    }

    public class Attributes
    {
        public static void Attr([CallerMemberNameAttribute] string numName = null,
                                [CallerFilePathAttribute] string fileName = null, 
                                [CallerLineNumberAttribute] int lineNumber = 0  )
        {
            WriteLine(numName);
            WriteLine(fileName);
            WriteLine(lineNumber);
        }
        
    }

    public class Tuples
    {
        public static void tuple()
        {

            static (string Name, int Age) GetPreson() => (Name: "Kamrul : ", Age: 24);
            Tuple<string, int, char> t = Tuple.Create("name", 24, 'M');
        }
    }

    public static class StringHalper
    {
        public static bool IsCapetalize(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return char.IsUpper(s[0]);
        }
    }

    public class Row
    {
        Array a = Array.CreateInstance(typeof(string), new int[] { 2 }, new int[] { 1 }); 
    }

    public class Enumarator
    {
        public static void FibnacciNumber()
        {
            foreach (int fib in EvenFibNum(Fib(6)))
                Write(fib + " ");
        }
        static IEnumerable<int> Fib(int fibCount)
        {
            for(int i = 0, preFib = 0, nextFib = 1; i <= fibCount; i++)
            {
                yield return preFib;
                int newFib = preFib + nextFib;
                preFib = nextFib;
                nextFib = newFib;
            }
        }
        static IEnumerable<int> EvenFibNum(IEnumerable<int> sequence)
        {
            foreach(int x in sequence)
            if (x % 2 == 0)
                yield return x;
        }
    }

    public class TryStatement
    {
        public static int Devide(int x) => 10 / x;
        public static void Do()
        {
            try
            {
                int y = Devide(0);
                Write(y);
            }
            catch(DivideByZeroException ex)
            {
                Write("X ix can't be zero");
            }
        }

    }

    public class CaptureIterationVariable
    {
        public static void CIV()
        {
            Action[] action = new Action[3];

            for (int i = 0; i < action.Length; i++)
                action[i] = () => Write(i);
            foreach (Action a in action)
                a();
        }
    }

    public class LamdaExpresion
    {
        public static void lem()
        {
            Func<string, string, int> totalLength = (s1, s2) => s1.Length + s2.Length;
            int total = totalLength("hello", "world");
            WriteLine(total);
        }
    }

    public class PriceChangeEventArg
    {
        public readonly decimal newPrice, lastPrice;

        public PriceChangeEventArg(decimal lastPrice, decimal newPrice)
        {
            this.lastPrice = lastPrice;
            this.newPrice = newPrice;
        }

    }
    public class Stack
    {
        string symble;
        decimal price;
        public Stack(string symble)
        {
            this.symble = symble;
        }
        public event EventHandler<PriceChangeEventArg> priceChange;
        protected void OnpriceChange(PriceChangeEventArg e)
        {
            priceChange?.Invoke(this, e);
        }
        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value) return;
                decimal OldPrice = price;
                price = value;
                OnpriceChange(new PriceChangeEventArg(OldPrice, price));
            }
        }



    }

    public delegate int Transformer(int x);
    public class Unit
    {
        public static void Transform(int [] value, Transformer t)
        {
            for(int i = 0; i < value.Length; i++)
            {
                value[i] = t(value[i]);
            }
        }
        public static int Square(int x) => x * x;
    }
}
