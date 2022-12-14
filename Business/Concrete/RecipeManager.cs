using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants.Messages;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Helpers;
using Microsoft.AspNetCore.Http;
using Core.Aspects.Autofac.Transaction;

namespace Business.Concrete
{
    public class RecipeManager : IRecipeService
    {
        private readonly IRecipeDal _recipeDal;

        public RecipeManager(IRecipeDal recipeDal)
        {
            _recipeDal = recipeDal;
        }

        [CacheRemoveAspect("IRecipeService.GetAll")]
        [ValidationAspect(typeof(RecipeValidator))]
        public IResult Add(IFormFile file, Recipe recipe)
        {
            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return imageResult;
            }

            recipe.ImagePath = imageResult.Message;

            _recipeDal.Add(recipe);
            return new SuccessResult(Messages.RecipeCreated);
        }

        [TransactionScopeAspect()]
        [CacheRemoveAspect("IRecipeService.Get")]
        public IResult Delete(Recipe recipe)
        {
            _recipeDal.Delete(recipe);
            return new SuccessResult(Messages.RecipeDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Recipe>> GetAll()
        {
            return new SuccessDataResult<List<Recipe>>(_recipeDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<int> GetAllRecipeLength()
        {
            return new SuccessDataResult<int>(_recipeDal.GetAll().Count);
        }

        [CacheAspect]
        public IDataResult<Recipe> GetById(int id)
        {
            return new SuccessDataResult<Recipe>(_recipeDal.Get(b => b.Id == id));
        }

        [CacheRemoveAspect("IRecipeService.Get")]
        [ValidationAspect(typeof(RecipeValidator))]
        public IResult Update(IFormFile file, Recipe recipe)
        {
            var imageResult = FileHelper.Update(file, recipe.ImagePath);

            if (!imageResult.Success)
            {
                return imageResult;
            }

            recipe.ImagePath = imageResult.Message;

            _recipeDal.Update(recipe);
            return new SuccessResult(Messages.RecipeUpdated);
        }
    }
}
