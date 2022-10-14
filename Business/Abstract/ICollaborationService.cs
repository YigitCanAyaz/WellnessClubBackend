using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICollaborationService
    {
        IDataResult<Collaboration> GetById(int id);
        IDataResult<List<Collaboration>> GetAll();
        IResult Add(IFormFile file, Collaboration collaboration);
        IResult Update(IFormFile file, Collaboration collaboration);
        IResult Delete(Collaboration collaboration);
        IDataResult<int> GetAllCollaborationLength();
    }
}
