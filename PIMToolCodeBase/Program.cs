using System;
using System.Configuration;
using System.Linq;
using Microsoft.Owin.Hosting;
using PIMToolCodeBase.Database;

namespace PIMToolCodeBase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = ConfigurationManager.AppSettings["host"];
            using (var server = WebApp.Start<Startup>(host))
            {
               
                using (var ctx = new PimContext())
                {
                   
                    //ctx.Employee.ToArray();
                    ctx.SaveChanges();
                }
                Console.WriteLine($"Hosted at {host}...");
                Console.WriteLine("Demo completed.");
                Console.ReadLine();
            }            
        }
    }
}