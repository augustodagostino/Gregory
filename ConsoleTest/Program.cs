using BusinessLayer;
using BusinessLayer.Models;
using System;
using System.Linq;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new GregoryContext())
            {
                var count = context.Set<Chain>().Count() + 1;
                var chain = new Chain { Code="CODE"+ count, Name="NAME "+ count };
                context.Add(chain);

                var first = context.Set<Chain>().OrderBy(o => o.Code).FirstOrDefault();
                first.Name = "AHORA HAY " + count;

                context.SaveChanges();

                var tabla = context.GetTableName<Chain>();

                Console.WriteLine(chain.UniqueId);
            }
        }
    }
}
