using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll(Func<Category,bool> filter = null);
        IDataResult<Category> GetById(int categoryId);
    }
}
