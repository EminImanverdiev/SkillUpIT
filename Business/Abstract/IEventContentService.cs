using Core.Utilities.Results.Abstract;
using Entities.DTOs.Events;
using Entities.DTOs.Events.EventContents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEventContentService
    {
        IDataResult<List<EventContentGetDto>> GetAll();
        IDataResult<EventContentGetDto> GetById(Guid id);
        IResult Add(EventContentCreateDto create);
        IResult Update(EventContentUpdateDto update);
    }
}
