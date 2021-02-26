using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.Concrete.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFProductDal : EFEntityRepoBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            var result = from p in GetAll()
                   join c in new EFCategoryDal().GetAll()
                   on p.CategoryId equals c.CategoryId
                   select new ProductDetailDto {
                       ProductId = p.ProductId, 
                       CategoryName = c.CategoryName,
                       ProductName = p.ProductName,
                       UnitsInStock = p.UnitsInStock 
                   };
            return result.ToList();
        }
    }
}
