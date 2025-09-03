using Core.Utilities.Results.Abstract;
using Entities.DTOs.ContactBlocks;

namespace Business.Abstract
{
    public interface IContactBlockService
    {
        IDataResult<List<ContactBlockGetDto>> GetAll();
        IDataResult<ContactBlockGetDto> GetById(Guid id);
        IResult Add(ContactBlockCreateDto create);
        IResult Update(ContactBlockUpdateDto update);

    }
}
