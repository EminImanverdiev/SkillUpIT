using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.DTOs.Events.EventContents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EventContentManager : IEventContentService
    {
        IEventContentDal _eventContentDal;

        public EventContentManager(IEventContentDal eventContentDal)
        {
            _eventContentDal = eventContentDal;
        }

        public IResult Add(EventContentCreateDto create)
        {
            var addedEventContent = new Entities.Concrete.Events.EventContent()
            {
                CreatedAt = DateTime.UtcNow,
                EventId = create.EventId,
                Tag= create.Tag,
            };
            _eventContentDal.Add(addedEventContent);
            return new SuccessResult("Event content added successfully.");

        }

        public IDataResult<List<EventContentGetDto>> GetAll()
        {
          var eventContents = _eventContentDal.GetAll();
            var modifiedEventContents = eventContents.Select(ec => new EventContentGetDto
            {
                Id = ec.Id,
                EventId = ec.EventId,
                Tag = ec.Tag,
            }).ToList();
            return new SuccessDataResult<List<EventContentGetDto>>(modifiedEventContents, "Event contents retrieved successfully.");
        }

        public IDataResult<EventContentGetDto> GetById(Guid id)
        {
           var eventContent = _eventContentDal.Get(x => x.Id == id);
            if (eventContent == null)
                return new ErrorDataResult<EventContentGetDto>(null, "Event content not found.");
            var modifiedEventContent = new EventContentGetDto
            {
                Id = eventContent.Id,
                EventId = eventContent.EventId,
                Tag = eventContent.Tag,
            };
            return new SuccessDataResult<EventContentGetDto>(modifiedEventContent, "Event content retrieved successfully.");
        }

        public IResult Update(EventContentUpdateDto update)
        {
           var eventContent = _eventContentDal.Get(x => x.Id == update.Id);
            if (eventContent == null)
                return new ErrorResult("Event content not found.");
            eventContent.EventId = update.EventId;
            eventContent.Tag = update.Tag;
            _eventContentDal.Update(eventContent);
            return new SuccessResult("Event content updated successfully.");
        }
    }
}
