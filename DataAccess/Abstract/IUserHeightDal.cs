using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IUserHeightDal : IEntityRepository<UserHeight>
    {
        List<UserHeightDetailDto> GetAllUserHeightDetails(Expression<Func<UserHeightDetailDto, bool>> filter = null);
        UserHeightDetailDto GetUserHeightDetails(Expression<Func<UserHeightDetailDto, bool>> filter);
    }
}
