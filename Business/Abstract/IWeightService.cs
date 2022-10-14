using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWeightService
    {
        IDataResult<Weight> GetById(int id);
        IDataResult<List<Weight>> GetAll();
        IResult Add(Weight weight);
        IResult Update(Weight weight);
        IResult Delete(Weight weight);
        IDataResult<int> GetAllWeightLength();
    }
}
