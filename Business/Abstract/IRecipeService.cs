using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRecipeService
    {
        IDataResult<Recipe> GetById(int id);
        IDataResult<List<Recipe>> GetAll();
        IResult Add(IFormFile file, Recipe recipe);
        IResult Update(IFormFile file, Recipe recipe);
        IResult Delete(Recipe recipe);
        IDataResult<int> GetAllRecipeLength();
    }
}
