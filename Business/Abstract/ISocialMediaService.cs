using Core.Utilities.Results.Abstract;
using Entities.DTOs.SocialMedias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISocialMediaService
    {
        IDataResult<List<SocialMediaGetDto>> GetAll();
        IDataResult<SocialMediaGetDto> GetById(Guid id);
        IResult Add(SocialMediaCreateDto create);
        IResult Update(SocialMediaUpdateDto update);
    }
}
