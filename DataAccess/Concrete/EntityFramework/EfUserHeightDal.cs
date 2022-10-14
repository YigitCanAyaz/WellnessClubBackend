using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserHeightDal : EfEntityRepositoryBase<UserHeight, WellnessClubContext>, IUserHeightDal
    {
        public List<UserHeightDetailDto> GetAllUserHeightDetails(Expression<Func<UserHeightDetailDto, bool>> filter = null)
        {
            using (WellnessClubContext context = new WellnessClubContext())
            {
                var result = (from userHeight in context.UserHeights
                              join user in context.Users on userHeight.UserId equals user.Id
                              join height in context.Heights on userHeight.HeightId equals height.Id
                              select new UserHeightDetailDto
                              {
                                  Id = userHeight.Id,
                                  UserId = user.Id,
                                  HeightId = height.Id,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  Email = user.Email,
                                  Gender = user.Gender,
                                  BirthDate = user.BirthDate,
                                  Status = user.Status,
                                  Meter = height.Meter

                              });

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public UserHeightDetailDto GetUserHeightDetails(Expression<Func<UserHeightDetailDto, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
