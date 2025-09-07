using Core.Utilities.Results.Abstract;
using Entities.DTOs.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITagService
    {
        IDataResult<List<TagGetDto>> GetAll();
        IDataResult<TagGetDto> GetById(Guid id);
        IResult Add(TagCreateDto create);
        IResult Update(TagUpdateDto update);
    }
}
