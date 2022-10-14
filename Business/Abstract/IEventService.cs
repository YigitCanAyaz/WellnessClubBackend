using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEventService
    {
        IDataResult<Event> GetById(int id);
        IDataResult<List<Event>> GetAll();
        IResult Add(Event evt);
        IResult Update(Event evt);
        IResult Delete(Event evt);
        IDataResult<int> GetAllEventLength();
    }
}
