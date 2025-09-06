using Business.Abstract;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.DTOs.SocialMedias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public IResult Add(SocialMediaCreateDto create)
        {
            var socialMedia = new Entities.Concrete.SocialMedia
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                InstructorId = create.InstructorId,
                Platform= create.Platform,
                Url= create.Url
            };
            _socialMediaDal.Add(socialMedia);
            return new Core.Utilities.Results.Concrete.SuccessResult("Social media added successfully.");
        }

        public IDataResult<List<SocialMediaGetDto>> GetAll()
        {
           var socialMedias = _socialMediaDal.GetAll();
            var socialMediaDtos = socialMedias.Select(sm => new SocialMediaGetDto
            {
                Id = sm.Id,
                InstructorId = sm.InstructorId,
                Platform = sm.Platform,
                Url = sm.Url
            }).ToList();
            return new Core.Utilities.Results.Concrete.SuccessDataResult<List<SocialMediaGetDto>>(socialMediaDtos, "Social medias retrieved successfully.");
        }

        public IDataResult<SocialMediaGetDto> GetById(Guid id)
        {
           var socialMedia = _socialMediaDal.Get(sm => sm.Id == id);
            if (socialMedia == null)
            {
                return new Core.Utilities.Results.Concrete.ErrorDataResult<SocialMediaGetDto>(null, "Social media not found.");
            }
            var socialMediaDto = new SocialMediaGetDto
            {
                Id = socialMedia.Id,
                InstructorId = socialMedia.InstructorId,
                Platform = socialMedia.Platform,
                Url = socialMedia.Url
            };
            return new Core.Utilities.Results.Concrete.SuccessDataResult<SocialMediaGetDto>(socialMediaDto, "Social media retrieved successfully.");
        }

        public IResult Update(SocialMediaUpdateDto update)
        {
            var socialMedia = _socialMediaDal.Get(sm => sm.Id == update.Id);
            if (socialMedia == null)
            {
                return new Core.Utilities.Results.Concrete.ErrorResult("Social media not found.");
            }
            socialMedia.Platform = update.Platform;
            socialMedia.Url = update.Url;
            _socialMediaDal.Update(socialMedia);
            return new Core.Utilities.Results.Concrete.SuccessResult("Social media updated successfully.");

        }
    }
}
