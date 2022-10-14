using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IHeightService
    {
        IDataResult<Height> GetById(int id);
        IDataResult<List<Height>> GetAll();
        IResult Add(Height height);
        IResult Update(Height height);
        IResult Delete(Height height);
        IDataResult<int> GetAllHeightLength();
    }
}
