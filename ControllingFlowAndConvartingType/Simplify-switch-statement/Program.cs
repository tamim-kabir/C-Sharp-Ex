using System;
using System.IO;


namespace Simplify_switch_statement
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"E:\Programs\c#\Chapter 3";

            Stream s = File.Open(Path.Combine(path, "file1.txt"), FileMode.OpenOrCreate);

            string massage = string.Empty;

            massage = s switch
            {
                FileStream wrteableFile when s.CanWrite
                =>"This stream have a file i can write too",
                FileStream readOnlyfile when s.CanRead
                => "This stream Only readable",
                MemoryStream ms
                => "This stream is a memory address",
                null
                =>"This stream is Null",
                _
                =>"This stream is some other type"
            };

            
            Console.WriteLine(massage);
        }
    }
}
