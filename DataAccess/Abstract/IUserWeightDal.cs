using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IUserWeightDal : IEntityRepository<UserWeight>
    {
        List<UserWeightDetailDto> GetAllUserWeightDetails(Expression<Func<UserWeightDetailDto, bool>> filter = null);
        UserWeightDetailDto GetUserWeightDetails(Expression<Func<UserWeightDetailDto, bool>> filter);
    }
}
