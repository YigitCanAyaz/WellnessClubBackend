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
    public class EfUserWeightDal : EfEntityRepositoryBase<UserWeight, WellnessClubContext>, IUserWeightDal
    {
        public List<UserWeightDetailDto> GetAllUserWeightDetails(Expression<Func<UserWeightDetailDto, bool>> filter = null)
        {
            using (WellnessClubContext context = new WellnessClubContext())
            {
                var result = (from userWeight in context.UserWeights
                              join user in context.Users on userWeight.UserId equals user.Id
                              select new UserWeightDetailDto
                              {
                                  Id = userWeight.Id,
                                  UserId = user.Id,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  Email = user.Email,
                                  Gender = user.Gender,
                                  BirthDate = user.BirthDate,
                                  Status = user.Status,
                                  Kilogram = userWeight.Kilogram

                              });

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public UserWeightDetailDto GetUserWeightDetails(Expression<Func<UserWeightDetailDto, bool>> filter)
        {
            using (WellnessClubContext context = new WellnessClubContext())
            {
                var result = (from userWeight in context.UserWeights
                              join user in context.Users on userWeight.UserId equals user.Id
                              select new UserWeightDetailDto
                              {
                                  Id = userWeight.Id,
                                  UserId = user.Id,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  Email = user.Email,
                                  Gender = user.Gender,
                                  BirthDate = user.BirthDate,
                                  Status = user.Status,
                                  Kilogram = userWeight.Kilogram

                              });

                return result.Where(filter).SingleOrDefault();
            }
        }
    }
}
