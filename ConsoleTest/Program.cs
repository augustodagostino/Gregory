using BusinessLayer;
using BusinessLayer.Models;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new GregoryContext())
            {
                var chain = new Chain { Code="CODE1",Name="NAME 1" };
                context.WTF.Add(chain);
                context.SaveChanges();

                Console.WriteLine(chain.UniqueId + ": " + chain.UniqueId);
            }
        }
    }
}
