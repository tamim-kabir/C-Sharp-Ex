using System;
using System.Net;
using System.Net.NetworkInformation;
using static System.Console;

namespace WorkingWithNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter a Web address: ");
            string url = ReadLine();
            if (string.IsNullOrWhiteSpace(url))
            {
                url = "https://google.com";
            }
            var uri = new Uri(url);
            WriteLine($"Url : {uri}");
            WriteLine($"Scheme: {uri.Scheme}");
            WriteLine($"Port: {uri.Port}");
            WriteLine($"Host: {uri.Host}");
            WriteLine($"Path: {uri.AbsolutePath}");
            WriteLine($"Query : {uri.Query}");
            IPHostEntry entry = Dns.GetHostEntry(uri.Host);
            Write($"{entry.HostName} has the followig IP adresses : ");
            foreach (IPAddress address in entry.AddressList)
            {
                WriteLine($"{address}");
            }

            try
            {
                var pin = new Ping();
                WriteLine("Pinging server please wait....");
                PingReply reply = pin.Send(uri.Host);
                WriteLine($"{uri.Host} was pining Reply : {reply.Status}");

                if (reply.Status == IPStatus.Success)
                    WriteLine($"Reply form {reply.Address}, took time: {reply.RoundtripTime} ms");
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType().ToString()} say {ex.Message}");
            }
        }
    }
}
