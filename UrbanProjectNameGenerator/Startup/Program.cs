using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using Nancy.Hosting.Self;

namespace UrbanProjectNameGenerator.Startup
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:3550");

            using (NancyHost host = new NancyHost(uri))
            {
                host.Start();

                Console.WriteLine("Urban Project Name Generator is runninong on" + uri);
                Console.WriteLine("Press any [Enter] to close the host.");
                Console.ReadLine();
            }
        }
    }
}
