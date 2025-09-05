using Core.Utilities.Results.Abstract;
using Entities.DTOs.Blogs;
using Entities.DTOs.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEventService
    {
        IDataResult<List<EventGetDto>> GetAll();
        IDataResult<EventGetDto> GetById(Guid id);
        IResult Add(EventCreateDto create);
        IResult Update(EventUpdateDto update);
        IDataResult<List<BlogGetDto>> GetAllFilter(int page, int limit);

    }
}
