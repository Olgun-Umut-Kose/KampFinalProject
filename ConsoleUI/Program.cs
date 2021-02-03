using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EFProductDal());

            
            foreach (Product p in productManager.GetByUnitPrice(40,100))
            {
                Console.WriteLine(p.ProductName);
            }

        }
    }
}
