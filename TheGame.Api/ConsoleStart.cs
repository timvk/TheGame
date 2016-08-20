namespace TheGame.Api
{
    using System;
    using Microsoft.Owin.Hosting;   

    public class ConsoleStart
    {
        public static void Main()
        {
            string url = "http://localhost:8080";
            WebApp.Start<Startup>(url);

            Console.WriteLine($"Server listening at {url}");

            Console.ReadLine();
        }
    }
}
