using Core.Utilities.Results.Abstract;
using Entities.DTOs.Partners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPartnerService
    {
        IDataResult<List<PartnerGetDto>> GetAll();
        IDataResult<PartnerGetDto> GetById(Guid id);
        IResult Add(PartnerCreateDto create);
        IResult Update(PartnerUpdateDto update);
    }
}
