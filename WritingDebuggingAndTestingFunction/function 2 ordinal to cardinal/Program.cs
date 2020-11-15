using System;


namespace function_2_ordinal_to_cardinal
{
    class Program
    {
        static string Ca_TO_Or(int n)
        {
            switch(n)              
            {
                case 11:
                case 12:
                case 13:
                    return $"{n}th";
                default:
                    string nAsT = n.ToString();
                    char lD = nAsT[nAsT.Length-1];
                    Console.WriteLine($"{lD}v");
                    string s = string.Empty;
                    switch(lD)
                    {
                        case '1':
                            s = "st";
                            break;
                        case '2':
                            s = "nd";
                            break;
                        case '3':
                            s = "rd";
                            break;
                        default:
                            s = "th";
                            break;
                    }
                    return $"{n}{s}";
            }
        }
        static void Run_Ca_To_Or()
        {
            for (int i = 1; i <= 30 ; i++)
                Console.Write($"{Ca_TO_Or(i)} ");

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Run_Ca_To_Or();
        }
    }
}
