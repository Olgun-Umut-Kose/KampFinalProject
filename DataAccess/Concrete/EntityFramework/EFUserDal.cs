using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserDal : EFEntityRepoBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from oc in context.OperationClaims
                    join uoc in context.UserOperationClaims
                        on oc.Id equals uoc.OperationClaimsId
                    where uoc.UserId == user.Id
                    select new OperationClaim {Id = oc.Id, Name = oc.Name};

                return result.ToList();

            }
        }
    }
}