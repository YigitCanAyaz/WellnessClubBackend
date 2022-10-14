using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IGalleryService
    {
        IDataResult<Gallery> GetById(int id);
        IDataResult<List<Gallery>> GetAll();
        IResult Add(Gallery gallery);
        IResult Update(Gallery gallery);
        IResult Delete(Gallery gallery);
        IDataResult<int> GetAllGalleryLength();
    }
}
