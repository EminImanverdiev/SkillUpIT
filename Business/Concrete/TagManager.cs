using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TagManager : ITagService
    {
        ITagDal _tagDal;

        public TagManager(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }

        public IResult Add(TagCreateDto create)
        {
           var tag =new Tag
            {
                Name = create.Name
            };
            _tagDal.Add(tag);
            return new SuccessResult("Tag added successfully.");
        }

        public IDataResult<List<TagGetDto>> GetAll()
        {
           var tags = _tagDal.GetAll();
            var tagDtos = tags.Select(t => new TagGetDto
            {
                Id = t.Id,
                Name = t.Name
            }).ToList();
            return new SuccessDataResult<List<TagGetDto>>(tagDtos, "Tags retrieved successfully.");
        }

        public IDataResult<TagGetDto> GetById(Guid id)
        {
            var tag = _tagDal.Get(t => t.Id == id);
            if (tag == null)
            {
                return new ErrorDataResult<TagGetDto>("Tag not found.");
            }
            var tagDto = new TagGetDto
            {
                Id = tag.Id,
                Name = tag.Name
            };
            return new SuccessDataResult<TagGetDto>(tagDto, "Tag retrieved successfully.");
        }

        public IResult Update(TagUpdateDto update)
        {
           var tag = _tagDal.Get(t => t.Id == update.Id);
            if (tag == null)
            {
                return new ErrorResult("Tag not found.");
            }
            tag.Name = update.Name;
            _tagDal.Update(tag);
            return new SuccessResult("Tag updated successfully.");
        }
    }
}
