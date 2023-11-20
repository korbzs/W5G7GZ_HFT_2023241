using System;
using System.Linq;
using W5G7GZ_HFT_2023241.Repository;

namespace W5G7GZ_HFT_2023241.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            BookStoreDbContext ctx = new BookStoreDbContext();

            var result = from x in ctx.Books.ToArray()
                         select x;
            foreach (var item in result)
            {
                Console.WriteLine(item.Title);
            }
        }
    }
}