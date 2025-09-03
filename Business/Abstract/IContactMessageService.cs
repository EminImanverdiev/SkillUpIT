using Core.Utilities.Results.Abstract;
using Entities.DTOs.ContactMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactMessageService
    {
        IDataResult<List<ContactMessageGetDto>> GetAll();
        IDataResult<ContactMessageGetDto> GetById(Guid id);
        IResult Add(ContactMessageCreateDto create);

    }
}
