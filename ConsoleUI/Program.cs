using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Product();

            //Category();

            ProductManager productManager = new ProductManager(new EFProductDal());

            foreach (ProductDetailDto productDetail in productManager.GetProductDetails())
            {
                Console.WriteLine(productDetail.ProductName + "/" + productDetail.CategoryName);
            }

        }

        private static void Category()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());

            foreach (Category category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        static void Product()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());


            foreach (Product p in productManager.GetByUnitPrice(40, 100))
            {
                Console.WriteLine(p.ProductName);
            }
        }
    }
}
