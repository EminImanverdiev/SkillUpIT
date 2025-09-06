using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EFDALs;
using Entities.Concrete;
using Entities.Concrete.Events;
using Entities.DTOs.Blogs;
using Entities.DTOs.Events;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EventManager : IEventService
    {
        IEventDal _eventDal;
        IFileService _service;

        public EventManager(IEventDal eventDal, IFileService service = null)
        {
            _eventDal = eventDal;
            _service = service;
        }

        public IResult Add(EventCreateDto create)
        {
            try
            {
                string? imageUrl = null;
                if (create.StartDate > create.EndDate)
                    return new ErrorResult("StartDate EndDate-dən böyük ola bilməz.");
                if (create.Url != null && create.Url.Length > 0)
                {
                    imageUrl = _service.UploadFileAsync(create.Url, "images").GetAwaiter().GetResult();
                }

                var addedEvent = new Event()
                {
                    CreatedAt = DateTime.UtcNow,
                    Title = create.Title,
                    Description = create.Description,
                    StartDate = create.StartDate,
                    EndDate = create.EndDate,
                    Location = create.Location,
                    Url = imageUrl,
                };

                _eventDal.Add(addedEvent);

                return new SuccessResult("Event added successfully.");
            }
            catch (DbUpdateException ex)
            {
                var inner = ex.InnerException?.Message ?? ex.Message;
                return new ErrorResult($"DB error: {inner}");
            }
        }

        public IDataResult<List<EventGetDto>> GetAll()
        {
            var events = _eventDal.GetAll();
            var modifiedEvents = events.Select(e => new EventGetDto
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Location = e.Location,
                Url = e.Url,
            }).ToList();
            return new SuccessDataResult<List<EventGetDto>>(modifiedEvents, "Events retrieved successfully.");
        }

        public IDataResult<List<BlogGetDto>> GetAllFilter(int page, int limit)
        {
            var events = _eventDal.GetAllFilter(
                            page, limit,
                            filter: null,
                            orderBy: q => q.OrderByDescending(e => e.CreatedAt)
                        )
                        .Select(e => new BlogGetDto
                        {
                            Id = e.Id,
                            Title = e.Title,
                            Content = e.Description,
                            ImageUrl = e.Url
                        }).ToList();
            return new SuccessDataResult<List<BlogGetDto>>(events, "Events retrieved successfully.");
        }

        public IDataResult<EventGetDto> GetById(Guid id)
        {
            var eventEntity = _eventDal.Get(e => e.Id == id);
            if (eventEntity == null)
                return new ErrorDataResult<EventGetDto>(null, "Event not found.");
            var modifiedEvent = new EventGetDto()
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title,
                Description = eventEntity.Description,
                StartDate = eventEntity.StartDate,
                EndDate = eventEntity.EndDate,
                Location = eventEntity.Location,
                Url = eventEntity.Url,

            };
            return new SuccessDataResult<EventGetDto>(modifiedEvent, "Event retrieved successfully.");
        }

        public IResult Update(EventUpdateDto update)
        {
            var eventEntity = _eventDal.Get(e => e.Id == update.Id);
            if (eventEntity == null)
                return new ErrorResult("Event not found.");
            if (update.StartDate > update.EndDate)
                return new ErrorResult("StartDate EndDate-dən böyük ola bilməz.");
            eventEntity.Title = update.Title;
            eventEntity.Description = update.Description;
            eventEntity.StartDate = update.StartDate;
            eventEntity.EndDate = update.EndDate;
            eventEntity.Location = update.Location;
            eventEntity.Url = update.Url;
            _eventDal.Update(eventEntity);
            return new SuccessResult("Event updated successfully.");
        }
    }
}
