using System;
using static System.Console;
using System.IO;


namespace Switch_statement
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"E:\Programs\c#\ControllingFlowAndConvartingType";
            Stream s = File.Open(Path.Combine(path, "file.txt"), FileMode.OpenOrCreate);
            string massage = string.Empty;
            switch (s)
            {
                case FileStream writeableFile when s.CanWrite:
                    massage = "This stream is a file That i can write too";
                    break;
                case FileStream readOnlyFile:
                    massage = "This stream is a read only file";
                    break;
                case MemoryStream ms:
                    massage = "This stream is memory address";
                    break;
                case null:
                    massage = "This strem is null";
                    break;
                default:
                    massage = "This stream is other type";
                    break;
            }
            WriteLine(massage);
        }
    }
}
