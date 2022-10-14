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
using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers;

namespace Business.Concrete
{
    public class CollaborationManager : ICollaborationService
    {
        private readonly ICollaborationDal _collaborationDal;

        public CollaborationManager(ICollaborationDal collaborationDal)
        {
            _collaborationDal = collaborationDal;
        }

        [CacheRemoveAspect("ICollaborationService.GetAll")]
        [ValidationAspect(typeof(CollaborationValidator))]
        public IResult Add(IFormFile file, Collaboration collaboration)
        {
            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return imageResult;
            }

            collaboration.ImagePath = imageResult.Message;

            _collaborationDal.Add(collaboration);
            return new SuccessResult(Messages.CollaborationCreated);
        }

        [CacheRemoveAspect("ICollaborationService.Get")]
        public IResult Delete(Collaboration collaboration)
        {
            _collaborationDal.Delete(collaboration);
            return new SuccessResult(Messages.CollaborationDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Collaboration>> GetAll()
        {
            return new SuccessDataResult<List<Collaboration>>(_collaborationDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<int> GetAllCollaborationLength()
        {
            return new SuccessDataResult<int>(_collaborationDal.GetAll().Count);
        }

        [CacheAspect]
        public IDataResult<Collaboration> GetById(int id)
        {
            return new SuccessDataResult<Collaboration>(_collaborationDal.Get(b => b.Id == id));
        }

        [CacheRemoveAspect("ICollaborationService.Get")]
        [ValidationAspect(typeof(CollaborationValidator))]
        public IResult Update(IFormFile file, Collaboration collaboration)
        {
            var imageResult = FileHelper.Update(file, collaboration.ImagePath);

            if (!imageResult.Success)
            {
                return imageResult;
            }

            collaboration.ImagePath = imageResult.Message;

            _collaborationDal.Update(collaboration);
            return new SuccessResult(Messages.CollaborationUpdated);
        }
    }
}
