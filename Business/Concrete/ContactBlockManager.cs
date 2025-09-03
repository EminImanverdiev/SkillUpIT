using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.ContactBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactBlockManager : IContactBlockService
    {
        IContactBlockDal _contactBlockDal;

        public ContactBlockManager(IContactBlockDal contactBlockDal)
        {
            _contactBlockDal = contactBlockDal;
        }

        public IResult Add(ContactBlockCreateDto create)
        {
            var addedContactBlock = new ContactBlock()
            {
                Id = Guid.NewGuid(),
                Title= create.Title,
                Description= create.Description,
                Icon= create.Icon
            };
            _contactBlockDal.Add(addedContactBlock);
            return new SuccessResult("Məlumatlar əlavə edildi");
        }

        public IDataResult<List<ContactBlockGetDto>> GetAll()
        {
            var contactBlocks = _contactBlockDal.GetAll();
            var modifiedContactBlocks = contactBlocks.Select(cb => new ContactBlockGetDto
            {
                Id = cb.Id,
                Title = cb.Title,
                Description = cb.Description,
                Icon = cb.Icon
            }).ToList();
            return new SuccessDataResult<List<ContactBlockGetDto>>(modifiedContactBlocks, "Məlumatlar göstərildi");
        }

        public IDataResult<ContactBlockGetDto> GetById(Guid id)
        {
            var contactBlock = _contactBlockDal.Get(x => x.Id == id);
            if (contactBlock == null)
                return new ErrorDataResult<ContactBlockGetDto>(null, "Məlumat tapılmadı");
            var modifiedContactBlock = new ContactBlockGetDto()
            {
                Id = contactBlock.Id,
                Title = contactBlock.Title,
                Description = contactBlock.Description,
                Icon = contactBlock.Icon
            };
            return new SuccessDataResult<ContactBlockGetDto>(modifiedContactBlock, "Məlumat göstərildi");
        }

        public IResult Update(ContactBlockUpdateDto update)
        {
            var contactBlockToUpdate = _contactBlockDal.Get(x => x.Id == update.Id);
            if (contactBlockToUpdate == null)
                return new ErrorResult("Məlumat tapılmadı");
            contactBlockToUpdate.Title = update.Title;
            contactBlockToUpdate.Description = update.Description;
            contactBlockToUpdate.Icon = update.Icon;
            _contactBlockDal.Update(contactBlockToUpdate);
            return new SuccessResult("Məlumat yeniləndi");
        }
    }
}
