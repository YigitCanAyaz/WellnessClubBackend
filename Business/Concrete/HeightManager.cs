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

namespace Business.Concrete
{
    public class HeightManager : IHeightService
    {
        private readonly IHeightDal _heightDal;

        public HeightManager(IHeightDal heightDal)
        {
            _heightDal = heightDal;
        }

        [CacheRemoveAspect("IHeightService.GetAll")]
        [ValidationAspect(typeof(HeightValidator))]
        public IResult Add(Height height)
        {
            _heightDal.Add(height);
            return new SuccessResult(Messages.HeightCreated);
        }

        [CacheRemoveAspect("IHeightService.Get")]
        public IResult Delete(Height height)
        {
            _heightDal.Delete(height);
            return new SuccessResult(Messages.HeightDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Height>> GetAll()
        {
            return new SuccessDataResult<List<Height>>(_heightDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<int> GetAllHeightLength()
        {
            return new SuccessDataResult<int>(_heightDal.GetAll().Count);
        }

        [CacheAspect]
        public IDataResult<Height> GetById(int id)
        {
            return new SuccessDataResult<Height>(_heightDal.Get(b => b.Id == id));
        }

        [CacheRemoveAspect("IHeightService.Get")]
        [ValidationAspect(typeof(HeightValidator))]
        public IResult Update(Height height)
        {
            _heightDal.Update(height);
            return new SuccessResult(Messages.HeightUpdated);
        }
    }
}
