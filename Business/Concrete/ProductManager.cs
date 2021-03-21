using Business.Abstract;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Validation;
using Core.Cross_Cutting_Concerns.Validation;
using Core.Utilities.Business;
using FluentValidation;
using FluentValidation.Results;


namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private ICategoryService _categoryService;


        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        
        [SecuredOperation("product.add", "admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckProductName(product));

            if (result != null) return result;

            _productDal.Add(product);
 
            return new SuccessResult(Messages.ProductAdded);
        }
        
        [CacheAspect()]
        public IDataResult<Product> GetById(int id)
        {
            Product result = _productDal.Get(p => p.ProductId == id);
            return new SuccessDataResult<Product>(Messages.ProductListed, result);
        }
        
        [CacheAspect()]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 9)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(Messages.ProductListed, _productDal.GetAll());
        }

        public IDataResult<List<Product>> GetByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(
                _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }


        private IResult CheckCategoryCount(Product product)
        {
            if (_productDal.GetAll(p => p.CategoryId == product.CategoryId).Count >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult CheckProductName(Product product)
        {
            if (_productDal.GetAll(p => p.ProductName == product.ProductName).Any())
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            return new SuccessResult();
        }
        
        private IResult CheckCategoryLimit(Product product)
        {
            if (_categoryService.GetAll().Data.Count >= 15)
            {
                return new ErrorResult(Messages.CategoryLimitError);
            }

            return new SuccessResult();
        }
    }
}