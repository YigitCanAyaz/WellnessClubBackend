using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICollaborationService
    {
        IDataResult<Collaboration> GetById(int id);
        IDataResult<List<Collaboration>> GetAll();
        IResult Add(Collaboration collaboration);
        IResult Update(Collaboration collaboration);
        IResult Delete(Collaboration collaboration);
        IDataResult<int> GetAllCollaborationLength();
    }
}
