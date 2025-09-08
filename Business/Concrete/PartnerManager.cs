using Business.Abstract;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.DTOs.Partners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PartnerManager : IPartnerService
    {
        IPartnerDal _partnerDal;

        public PartnerManager(IPartnerDal partnerDal)
        {
            _partnerDal = partnerDal;
        }

        public IResult Add(PartnerCreateDto create)
        {
           var partner = new Entities.Concrete.Partner
            {
                Name = create.Name,
                Description = create.Description,
                ImageUrl = create.ImageUrl,
                WebsiteUrl = create.WebsiteUrl
            };
            _partnerDal.Add(partner);
            return new Core.Utilities.Results.Concrete.SuccessResult();
        }

        public IDataResult<List<PartnerGetDto>> GetAll()
        {
             var partners = _partnerDal.GetAll();
            var partnerDtos = partners.Select(p => new PartnerGetDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                WebsiteUrl = p.WebsiteUrl
            }).ToList();
            return new Core.Utilities.Results.Concrete.SuccessDataResult<List<PartnerGetDto>>(partnerDtos);
        }

        public IDataResult<PartnerGetDto> GetById(Guid id)
        {
           var partner = _partnerDal.Get(p => p.Id == id);
            if (partner == null)
            {
                return new Core.Utilities.Results.Concrete.ErrorDataResult<PartnerGetDto>("Partner not found");
            }
            var partnerDto = new PartnerGetDto
            {
                Id = partner.Id,
                Name = partner.Name,
                Description = partner.Description,
                ImageUrl = partner.ImageUrl,
                WebsiteUrl = partner.WebsiteUrl
            };
            return new Core.Utilities.Results.Concrete.SuccessDataResult<PartnerGetDto>(partnerDto);
        }

        public IResult Update(PartnerUpdateDto update)
        {
            var partner = _partnerDal.Get(p => p.Id == update.Id);
            if (partner == null)
            {
                return new Core.Utilities.Results.Concrete.ErrorResult("Partner not found");
            }
            partner.Name = update.Name;
            partner.Description = update.Description;
             partner.ImageUrl = update.ImageUrl;
            partner.WebsiteUrl = update.WebsiteUrl;
            _partnerDal.Update(partner);
            return new Core.Utilities.Results.Concrete.SuccessResult();

        }
    }
}
