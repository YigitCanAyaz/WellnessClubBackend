using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserHeightService
    {
        IDataResult<UserHeight> GetById(int id);
        IDataResult<List<UserHeight>> GetAll();
        IResult Add(UserHeight userHeight);
        IResult Update(UserHeight userHeight);
        IResult Delete(UserHeight userHeight);

        IDataResult<List<UserHeight>> GetAllUserHeightsByUserId(int userId);
        IDataResult<int> GetAllUserHeightLength();

        IDataResult<List<UserHeightDetailDto>> GetAllUserHeightDetails();
        IDataResult<List<UserHeightDetailDto>> GetAllUserHeightDetailsByUserId(int userId);
        IDataResult<UserHeightDetailDto> GetUserHeightDetailsById(int id);
    }
}
