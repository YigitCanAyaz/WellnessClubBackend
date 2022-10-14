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
    public class WeightManager : IWeightService
    {
        private readonly IWeightDal _weightDal;

        public WeightManager(IWeightDal weightDal)
        {
            _weightDal = weightDal;
        }

        [CacheRemoveAspect("IWeightService.GetAll")]
        [ValidationAspect(typeof(WeightValidator))]
        public IResult Add(Weight weight)
        {
            _weightDal.Add(weight);
            return new SuccessResult(Messages.WeightCreated);
        }

        [CacheRemoveAspect("IWeightService.Get")]
        public IResult Delete(Weight weight)
        {
            _weightDal.Delete(weight);
            return new SuccessResult(Messages.WeightDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Weight>> GetAll()
        {
            return new SuccessDataResult<List<Weight>>(_weightDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<int> GetAllWeightLength()
        {
            return new SuccessDataResult<int>(_weightDal.GetAll().Count);
        }

        [CacheAspect]
        public IDataResult<Weight> GetById(int id)
        {
            return new SuccessDataResult<Weight>(_weightDal.Get(b => b.Id == id));
        }

        [CacheRemoveAspect("IWeightService.Get")]
        [ValidationAspect(typeof(WeightValidator))]
        public IResult Update(Weight weight)
        {
            _weightDal.Update(weight);
            return new SuccessResult(Messages.WeightUpdated);
        }
    }
}
