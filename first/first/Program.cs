using System;
using System.Text;
using static System.Console;


namespace first
{
    class Program
    {
        public static object Systam { get; private set; }
        public class B
        {
            public void A()
            {
                WriteLine(" in nest class B");
            }
        }
        static void Main(string[] args)
        {
            GenericStack();
        }
        static void zoo()
        {
            Stak<Beer> beers = new Stak<Beer>();
            ZooCleaner.Wash(beers);
        }    
        static void SelfRefGen()
        {
            
        }
        static void GenericStack()
        {
            sack m = new sack();
            int a = 5, b = 10;
            WriteLine("Generic Function type");
            WriteLine($"Before function call {a} and {b}\n");
            m.data(ref a, ref b);
            WriteLine($"After function call {a} and {b}\n");            
        }
        static void Generic()
        {
            var data = new Stack<int>();
            data.Push(5);
            data.Push(2);
            
            int x = data.Pop();
            int y = data.Pop();
         
            WriteLine($"{x} and {y}");
        }
        static void Interface()
        {
            IMuloter e = new CounDown();
            while (e.MoveNext())
                Write(e.Current);
        }
        static void Virtual()
        {
            SubClass1 tamim = new SubClass1 { name = "Tamim", mortgage = 101 };
            if (tamim is SubClass1 s && s.mortgage > 100)
                WriteLine($"Name : {s.name} \nLibality : {s.Libility} Tk");
            else
                WriteLine($"Name : {tamim.name} \nLibality : {tamim.mortgage}tk \nHe can apply for loan");

        }
        static void IsOperator()
        {
            SubClass a = new SubClass();
            if (a is SubClass s && s.sharedWon >= 100)
                WriteLine("Helthy");
            else
                s = new SubClass();
            WriteLine($"Your Share is {s.sharedWon}");
        }
        static void pro()
        {
            Propertice protec = new Propertice();
            protec.CurrentPrice = 40;
            protec.CurrentPrice += 23;
            protec.Price = 30;
            protec.Price += 30;
            WriteLine(protec.CurrentPrice + " " + protec.Price);
        }
        static void ProSectance()
        {
            Sectance word = new Sectance();
            WriteLine(word[1]);
            word[3] = "Tom cruse";
            WriteLine(word[3]);
        }
        static void c()
        {
            string s = "My Name is tamim";
            TheThisRef dosobu = new TheThisRef();
            dosobu.Mate(s);
            dosobu.mate2();
        }
        static void C()
        {
            var p = new deconstruct("Md", "Tamim", "kabir", "Tem", "Dhaka", "01642400166");
            var (fname, mname, lname, phone) = p;
            WriteLine($"Hello {fname} {mname} {lname} your {phone} Number!!");

        }
    }

    public class Animal
    {

    }
    public class Beer : Animal
    {

    }
    public class Camal : Animal
    {

    }
    public class Stak<T>
    {
        int possition;
        T[] data = new T[100];
        public void Push(T obj) => data[possition++] = obj;
        public T Pop() => data[--possition];
    }
    public class ZooCleaner
    {
        public static void Wash<T>(Stak<T> animals)
        {

        }
    }
  
    public class stringbuilder
    {
        StringBuilder Foo<T>(T arg)
        {
            StringBuilder sb = arg as StringBuilder;
            if (sb != null)
                return sb;
            return sb;          
        }
    }

    //Self-Referencing Generic Declarations with interface
    public interface IEquable<T> { bool Equal(T obj); }
    public class Ballon : IEquable<Ballon>
    {
        public string color { get; set; }
        public int Cc { get; set; }
        bool Equal(Ballon b)
        {
            if(b == null)return false;
            return b.color == color && b.Cc == Cc;
        }

        bool IEquable<Ballon>.Equal(Ballon obj)
        {
            throw new NotImplementedException();
        }
    }
        
    public interface IComparable<T>
    {
        int CompareTo(T other);
    }
    public class Com
    {
        public static T Max<T>(T a, T b) where T: IComparable<T> => a.CompareTo(b) > 0 ? a : b;
      
    }
    public class sack
    {
        public void data<t>(ref t a, ref t b)
        {
            t temp = a;
            a = b;
            b = temp;
        }
    }
    public class Stack<T>
    {
        int possition;
        T[] data = new T[10];
        public void Push(T o) => data[possition++] = o;
        public T Pop() => data[--possition];
    }
    public interface IMuloter
    {
        bool MoveNext();
        object Current { get; }
        void Rest();
    }
    internal class CounDown : IMuloter
    {
        int count = 11;
        public bool MoveNext() => count-- > 0;
        public object Current => count;
        public void Rest()
        {
            throw new NotSupportedException(); 
        }
    }
    public abstract class Assat
    {
        public abstract decimal NetValue { get; }
    }
    public class Home : Assat
    {
        decimal CurrentPrice;
        int OldProice;
        public override decimal NetValue => (CurrentPrice * OldProice);
    }
    public class SuperClass
    {
        public string name;
        public virtual decimal Libility
        {
            get { return 0; }
        }
    }
    public class SubClass : SuperClass
    {
        public long sharedWon;
    }
    public class SubClass1 : SuperClass
    {
        public decimal mortgage;
        public override decimal Libility => base.Libility + mortgage;
    }
    public class Sectance
    {
        string[] word = "this ia model sentance".Split();
        public string this[int wordNum]
        {
            get{return word[wordNum];}
            set{ word[wordNum] = value; }

        }
    }
    public class Propertice
    {
        decimal currentPrice;
        decimal tol;     // The private "backing" field
        public decimal CurrentPrice    // The public property
        {
            get { return currentPrice; }
            set { currentPrice = value; }
        }
        public decimal Price
        {
            get { return tol; }
            set { tol = value; }
        }

    }
    public class Panda
    {
        public Panda Mate;
        public void Marry( Panda partner)
        {
            Mate = partner;
            partner.Mate = this;
        }
    }
    public class TheThisRef
    {
        string name;
        public void Mate(string name)
        {
            this.name = name;
          
        }
        public void mate2()
        {
            WriteLine(name);
        }
    }
    public class Textbuilder1
    {
        public static void TextString1()
        {
            StringBuilder sb = null; ;
            int? s = sb?.ToString().Length;
            WriteLine(s);
        }
    }
    public class Params
    {
        public static int sum(params int[] ints)
        {
            int total = 0;
            for (int i = 0; i < ints.Length; i++)
                total += ints[i];
            return total;
        }
    }
    public class Refrance
    {
        public static void Paramiter(string name, out string a, out string b)
        {
            int i = name.LastIndexOf(" ");
            a = name.Substring(0, i);
            b = name.Substring(i + 1);
        }
    }
    public class refance
    {
        public static void dataEx(ref int x)
        {
            x = x + 3;
        }
        public static void StringRef(ref string a, ref string b)
        {
            string tamp = a;
            a = b;
            b = tamp;
        }
    }
    public class Convarter
    {
        float ratio = 1;
        int bynary = 0b1101_1111_1000_1110_0010;
        double dou = 1E06;

        public Convarter(float UntiRatio)
        {
            ratio = UntiRatio;
        }
        public float UnitCon(float unti)
        {
            return ratio * unti;
        }
    }
    public class deconstruct
    {
        string FName, MName, LName, NicNmae, Address, Phone;
        public deconstruct( string fName, string mName, string lName, string nicNmae, string address, string phone)
        {
            FName = fName;
            MName = mName;
            LName = lName;
            NicNmae = nicNmae;
            Address = address;
            Phone = phone;
        }

        public void Deconstruct(out string fname, out string mname, out string lname, out string phone)
        {
            fname = FName;
            mname = MName;
            lname = LName;
            phone = Phone;
        }
    }
    public class array
    {
        public static void MultidimetionArray()
        {
            int[,] name = new int[3, 3];
            for (int i = 0; i < name.GetLength(0); i++)
            {
                for (int j = 0; j < name.GetLength(1); j++)
                {
                    name[i, j] = i * 3 + j;
                }
            }

            for (int i = 0; i < name.GetLength(0); i++)
            {
                for (int j = 0; j < name.GetLength(1); j++)
                {
                    Write(name[i, j] + "  ");
                }
                Write("\n\n");
            }
        }
    }
    public class jaggedArray
    {
        public static void MultidimenJagArray()
        {
            int[][] jagged = new int[3][];

            for (int i = 0; i < jagged.Length; i++)
            {
                jagged[i] = new int[3];
                for (int j = 0; j < jagged.Length; j++)
                {
                    jagged[i][j] = i * 3 + j;
                }

            }
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged.Length; j++)
                {
                    Write(jagged[i][j] + "  ");
                }
                Write("\n\n");
            }
        }

    }
    public class Person
    {
        public Person()
        {

        }
        public static void tuples()
        {
            var Tuple = (Name: "Tamim", Age: "21");
            Console.WriteLine(Tuple.Name);
            Console.WriteLine(Tuple.Age);
            var tu = ("we are going to end this", 23, "decmber");
            Console.WriteLine(tu.Item1);
            Console.WriteLine(tu.Item2);
            Console.WriteLine(tu.Item3);
        }
        public static (int row, int col) GetPossition()
        {
            return (3, 10);
        }
        public string[] array = new string[] { };
        public string foo() => throw new NotImplementedException();
        public static void stringBulder()
        {
            System.Text.StringBuilder sb = null;
            _ = sb?.ToString();
        }
        public int TimeTwo(int x) => x * 2;
        public string someProperty => "property vale";
        public DateTime timeCreate { get; set; } = DateTime.Now;



        ~Person() => Console.WriteLine("finish");

    }
    public class newclaa
    {
        public static void foo(Object x)
        {
            switch (x)
            {
                case int _:
                    Console.WriteLine("this is int");
                    break;
                case string _:
                    Console.WriteLine("this is string");
                    break;
                case bool b when b == true:
                    Console.WriteLine("this is boolean");
                    break;
                case (null):
                    Console.WriteLine("There is nothing");
                    break;
            }
        }




        /*
        public static void WriteCube() 
        {
            Console.WriteLine(Cube(3));
            Console.WriteLine(Cube(5));
            Console.WriteLine(Cube(6));

            int cube(int value) => value * value * value;
        }*/
    }
    public class overloding
    {
        public int price;
        public string name;
        public overloding(int Price)
        {
            price = Price;
        }
        public overloding(int Price, string Name) : this()
        {
            name = Name;
            WriteLine($"the name is {name} price is {Price}");
        }
        public overloding()
        {
            
        }


    }
}



namespace B
{
    public class T
    {
        public static void Mood()
        {
            WriteLine("In global class T");
        }
    }
}

