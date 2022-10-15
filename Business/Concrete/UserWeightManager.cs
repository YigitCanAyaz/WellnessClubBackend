using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Entities.DTOs;
using DataAccess.Concrete.EntityFramework;

namespace Business.Concrete
{
    public class UserWeightManager : IUserWeightService
    {
        private readonly IUserWeightDal _userWeightDal;

        public UserWeightManager(IUserWeightDal userWeightDal)
        {
            _userWeightDal = userWeightDal;
        }

        [CacheRemoveAspect("IUserWeightService.GetAll")]
        [ValidationAspect(typeof(UserWeightValidator))]
        public IResult Add(UserWeight userWeight)
        {
            _userWeightDal.Add(userWeight);
            return new SuccessResult(Messages.UserWeightCreated);
        }

        [CacheRemoveAspect("IUserWeightService.Get")]
        public IResult Delete(UserWeight userWeight)
        {
            _userWeightDal.Delete(userWeight);
            return new SuccessResult(Messages.UserWeightDeleted);
        }

        [CacheAspect]
        public IDataResult<List<UserWeight>> GetAll()
        {
            return new SuccessDataResult<List<UserWeight>>(_userWeightDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<UserWeight> GetById(int id)
        {
            return new SuccessDataResult<UserWeight>(_userWeightDal.Get(c => c.Id == id));
        }

        [CacheRemoveAspect("IUserWeightService.Get")]
        [ValidationAspect(typeof(UserWeightValidator))]
        public IResult Update(UserWeight userWeight)
        {
            _userWeightDal.Update(userWeight);
            return new SuccessResult(Messages.UserWeightUpdated);
        }

        [CacheAspect]
        public IDataResult<List<UserWeightDetailDto>> GetAllUserWeightDetails()
        {
            return new SuccessDataResult<List<UserWeightDetailDto>>(_userWeightDal.GetAllUserWeightDetails());
        }

        public IDataResult<UserWeightDetailDto> GetUserWeightDetailsById(int id)
        {
            return new SuccessDataResult<UserWeightDetailDto>(_userWeightDal.GetUserWeightDetails(m => m.Id == id));
        }

        public IDataResult<int> GetAllUserWeightLength()
        {
            return new SuccessDataResult<int>(_userWeightDal.GetAll().Count);
        }

        public IDataResult<List<UserWeight>> GetAllUserWeightsByUserId(int userId)
        {
            return new SuccessDataResult<List<UserWeight>>(_userWeightDal.GetAll(u => u.UserId == userId));
        }

        public IDataResult<List<UserWeightDetailDto>> GetAllUserWeightDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<UserWeightDetailDto>>(_userWeightDal.GetAllUserWeightDetails(u => u.UserId == userId));
        }
    }
}
