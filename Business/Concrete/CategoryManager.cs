using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _dal;

        public CategoryManager(ICategoryDal dal)
        {
            _dal = dal;
        }

        public IDataResult<List<Category>> GetAll(Func<Category,bool> filter = null)
        {
            return new SuccessDataResult<List<Category>>(_dal.GetAll(filter));
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_dal.Get(c => c.CategoryId == categoryId));
        }
    }
}
