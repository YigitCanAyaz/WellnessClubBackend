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

namespace Business.Concrete
{
    public class EventManager : IEventService
    {
        private readonly IEventDal _evtDal;

        public EventManager(IEventDal evtDal)
        {
            _evtDal = evtDal;
        }

        [CacheRemoveAspect("IEventService.GetAll")]
        [ValidationAspect(typeof(EventValidator))]
        public IResult Add(IFormFile file, Event evt)
        {
            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return imageResult;
            }

            evt.ImagePath = imageResult.Message;

            _evtDal.Add(evt);
            return new SuccessResult(Messages.EventCreated);
        }

        [CacheRemoveAspect("IEventService.Get")]
        public IResult Delete(Event evt)
        {
            _evtDal.Delete(evt);
            return new SuccessResult(Messages.EventDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Event>> GetAll()
        {
            return new SuccessDataResult<List<Event>>(_evtDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<int> GetAllEventLength()
        {
            return new SuccessDataResult<int>(_evtDal.GetAll().Count);
        }

        [CacheAspect]
        public IDataResult<Event> GetById(int id)
        {
            return new SuccessDataResult<Event>(_evtDal.Get(b => b.Id == id));
        }

        [CacheRemoveAspect("IEventService.Get")]
        [ValidationAspect(typeof(EventValidator))]
        public IResult Update(IFormFile file, Event evt)
        {
            var imageResult = FileHelper.Update(file, evt.ImagePath);

            if (!imageResult.Success)
            {
                return imageResult;
            }

            evt.ImagePath = imageResult.Message;

            _evtDal.Update(evt);
            return new SuccessResult(Messages.EventUpdated);
        }
    }
}
