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
    public class GalleryManager : IGalleryService
    {
        private readonly IGalleryDal _galleryDal;

        public GalleryManager(IGalleryDal galleryDal)
        {
            _galleryDal = galleryDal;
        }

        [CacheRemoveAspect("IGalleryService.GetAll")]
        [ValidationAspect(typeof(GalleryValidator))]
        public IResult Add(IFormFile file, Gallery gallery)
        {
            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return imageResult;
            }

            gallery.ImagePath = imageResult.Message;

            _galleryDal.Add(gallery);
            return new SuccessResult(Messages.GalleryCreated);
        }

        [CacheRemoveAspect("IGalleryService.Get")]
        public IResult Delete(Gallery gallery)
        {
            _galleryDal.Delete(gallery);
            return new SuccessResult(Messages.GalleryDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Gallery>> GetAll()
        {
            return new SuccessDataResult<List<Gallery>>(_galleryDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<int> GetAllGalleryLength()
        {
            return new SuccessDataResult<int>(_galleryDal.GetAll().Count);
        }

        [CacheAspect]
        public IDataResult<Gallery> GetById(int id)
        {
            return new SuccessDataResult<Gallery>(_galleryDal.Get(b => b.Id == id));
        }

        [CacheRemoveAspect("IGalleryService.Get")]
        [ValidationAspect(typeof(GalleryValidator))]
        public IResult Update(IFormFile file, Gallery gallery)
        {
            var imageResult = FileHelper.Update(file, gallery.ImagePath);

            if (!imageResult.Success)
            {
                return imageResult;
            }

            gallery.ImagePath = imageResult.Message;

            _galleryDal.Update(gallery);
            return new SuccessResult(Messages.GalleryUpdated);
        }
    }
}
