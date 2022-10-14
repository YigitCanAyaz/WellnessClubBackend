using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IGalleryService
    {
        IDataResult<Gallery> GetById(int id);
        IDataResult<List<Gallery>> GetAll();
        IResult Add(IFormFile file, Gallery gallery);
        IResult Update(IFormFile file, Gallery gallery);
        IResult Delete(Gallery gallery);
        IDataResult<int> GetAllGalleryLength();
    }
}
