using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEventService
    {
        IDataResult<Event> GetById(int id);
        IDataResult<List<Event>> GetAll();
        IResult Add(IFormFile file, Event evt);
        IResult Update(IFormFile file, Event evt);
        IResult Delete(Event evt);
        IDataResult<int> GetAllEventLength();
    }
}
