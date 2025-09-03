using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.Fags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFagService
    {
        IDataResult<List<FagGetDto>> GetAll();
        IDataResult<FagGetDto> GetById(Guid id);
        IResult Add(FagCreateDto create);
        IResult Update(FagUpdateDto update);
    }
}
