using Nancy.Hosting.Self;
using System;

namespace Persons.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            NancyHost host = new NancyHost(new Uri("http://localhost:1234"), new Bootstrapper());
            host.Start();
            Console.WriteLine("nancy host running...");
            Console.WriteLine("press enter to stop");
            Console.ReadLine();
            Console.WriteLine("nancy host STOPPED!");
            host.Stop();
            //ConfigureService.Configure();
        }
    }
}
