using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _dal;

        public CategoryManager(ICategoryDal dal)
        {
            _dal = dal;
        }

        public List<Category> GetAll()
        {
            return _dal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _dal.Get(c => c.CategoryId == categoryId);
        }
    }
}
