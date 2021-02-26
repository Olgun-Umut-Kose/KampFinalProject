using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using Core.Utilities.Results;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Product();

            //Category();

            //ProductDetail();
            
        }

        private static void ProductDetail()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());

            var result = productManager.GetProductDetails();

            if (result.Success)
            {
                foreach (ProductDetailDto productDetail in result.Data)
                {
                    Console.WriteLine(productDetail.ProductName + "/" + productDetail.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
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

            var result = productManager.GetByUnitPrice(40, 100);
            
            if (result.Success)
            {
                foreach (Product p in result.Data)
                {
                    Console.WriteLine(p.ProductName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
        
    }

        
    
}
