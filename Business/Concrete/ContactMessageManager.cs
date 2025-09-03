using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.DTOs.ContactMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactMessageManager : IContactMessageService
    {
        IContactMessageDal _contactmessagedal;

        public ContactMessageManager(IContactMessageDal contactmessagedal)
        {
            _contactmessagedal = contactmessagedal;
        }

        public IResult Add(ContactMessageCreateDto create)
        {
            var addedContactMessage = new Entities.Concrete.ContactMessage()
            {
                Id = Guid.NewGuid(),
                Name = create.Name,
                Email = create.Email,
                Subject = create.Subject,
                Message = create.Message,
            };
            _contactmessagedal.Add(addedContactMessage);
            return new SuccessResult("Məlumatlar əlavə edildi");
        }

        public IDataResult<List<ContactMessageGetDto>> GetAll()
        {
            var contactMessages = _contactmessagedal.GetAll();
            var modifiedContactMessages = contactMessages.Select(cm => new ContactMessageGetDto
            {
                Id = cm.Id,
                Name = cm.Name,
                Email = cm.Email,
                Subject = cm.Subject,
                Message = cm.Message,
            }).ToList();
            return new SuccessDataResult<List<ContactMessageGetDto>>(modifiedContactMessages, "Məlumatlar göstərildi");
        }

        public IDataResult<ContactMessageGetDto> GetById(Guid id)
        {
            var contactMessage = _contactmessagedal.Get(x => x.Id == id);
            if (contactMessage == null)
                return new ErrorDataResult<ContactMessageGetDto>(null, "Məlumat tapılmadı");
            var modifiedContactMessage = new ContactMessageGetDto()
            {
                Id = contactMessage.Id,
                Name = contactMessage.Name,
                Email = contactMessage.Email,
                Subject = contactMessage.Subject,
                Message = contactMessage.Message,
            };
            return new SuccessDataResult<ContactMessageGetDto>(modifiedContactMessage, "Məlumat göstərildi");
        }

    
    }
}
