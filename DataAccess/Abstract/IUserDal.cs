using System.Collections.Generic;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepo<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}