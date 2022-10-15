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
    public class UserHeightManager : IUserHeightService
    {
        private readonly IUserHeightDal _userHeightDal;

        public UserHeightManager(IUserHeightDal userHeightDal)
        {
            _userHeightDal = userHeightDal;
        }

        [CacheRemoveAspect("IUserHeightService.GetAll")]
        [ValidationAspect(typeof(UserHeightValidator))]
        public IResult Add(UserHeight userHeight)
        {
            _userHeightDal.Add(userHeight);
            return new SuccessResult(Messages.UserHeightCreated);
        }

        [CacheRemoveAspect("IUserHeightService.Get")]
        public IResult Delete(UserHeight userHeight)
        {
            _userHeightDal.Delete(userHeight);
            return new SuccessResult(Messages.UserHeightDeleted);
        }

        [CacheAspect]
        public IDataResult<List<UserHeight>> GetAll()
        {
            return new SuccessDataResult<List<UserHeight>>(_userHeightDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<UserHeight> GetById(int id)
        {
            return new SuccessDataResult<UserHeight>(_userHeightDal.Get(c => c.Id == id));
        }

        [CacheRemoveAspect("IUserHeightService.Get")]
        [ValidationAspect(typeof(UserHeightValidator))]
        public IResult Update(UserHeight userHeight)
        {
            _userHeightDal.Update(userHeight);
            return new SuccessResult(Messages.UserHeightUpdated);
        }

        [CacheAspect]
        public IDataResult<List<UserHeightDetailDto>> GetAllUserHeightDetails()
        {
            return new SuccessDataResult<List<UserHeightDetailDto>>(_userHeightDal.GetAllUserHeightDetails());
        }
        public IDataResult<UserHeightDetailDto> GetUserHeightDetailsById(int id)
        {
            return new SuccessDataResult<UserHeightDetailDto>(_userHeightDal.GetUserHeightDetails(m => m.Id == id));
        }

        public IDataResult<int> GetAllUserHeightLength()
        {
            return new SuccessDataResult<int>(_userHeightDal.GetAll().Count);
        }

        public IDataResult<List<UserHeight>> GetAllUserHeightsByUserId(int userId)
        {
            return new SuccessDataResult<List<UserHeight>>(_userHeightDal.GetAll(u => u.UserId == userId));
        }

        public IDataResult<List<UserHeightDetailDto>> GetAllUserHeightDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<UserHeightDetailDto>>(_userHeightDal.GetAllUserHeightDetails(u => u.UserId == userId));
        }
    }
}
