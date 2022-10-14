using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserWeightService
    {
        IDataResult<UserWeight> GetById(int id);
        IDataResult<List<UserWeight>> GetAll();
        IResult Add(UserWeight userWeight);
        IResult Update(UserWeight userWeight);
        IResult Delete(UserWeight userWeight);

        IDataResult<int> GetAllUserWeightLength();

        IDataResult<List<UserWeightDetailDto>> GetAllUserWeightDetails();
        IDataResult<UserWeightDetailDto> GetUserWeightDetailsById(int id);
    }
}
