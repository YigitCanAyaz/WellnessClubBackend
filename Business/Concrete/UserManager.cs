using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Entities.DTOs;
using Core.Utilities.Security.Hashing;
using Core.Aspects.Autofac.Transaction;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<OperationClaim>> GetAllClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetAllClaims(user));
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserCreated);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        //[SecuredOperation("admin")]
        public IDataResult<List<UserForInfoDto>> GetAll()
        {
            return new SuccessDataResult<List<UserForInfoDto>>(_userDal.GetAllUserDetails());
        }

        public IDataResult<UserForInfoDto> GetById(int id)
        {
            return new SuccessDataResult<UserForInfoDto>(_userDal.GetUserDetails(u => u.Id == id));
        }

        public IResult ChangePassword(ChangePasswordDto user)
        {
            var userToUpdate = GetByMail(user.Email).Data;

            if (HashingHelper.VerifyPasswordHash(user.OldPassword, userToUpdate.PasswordHash, userToUpdate.PasswordSalt))
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(user.NewPassword, out passwordHash, out passwordSalt);
                userToUpdate.PasswordHash = passwordHash;
                userToUpdate.PasswordSalt = passwordSalt;
                _userDal.Update(userToUpdate);
                return new SuccessResult(Messages.PasswordUpdated);
            }
            return new ErrorResult(Messages.PasswordError);
        }

        public IResult Update(UserForInfoDto user)
        {
            var userToUpdate = GetByMail(user.Email).Data;

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            _userDal.Update(userToUpdate);
            return new SuccessResult(Messages.UserUpdated);
        }

        [TransactionScopeAspect()]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }
    }
}
