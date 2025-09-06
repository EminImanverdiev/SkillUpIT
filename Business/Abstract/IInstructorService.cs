using Core.Utilities.Results.Abstract;
using Entities.DTOs.Instructors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IInstructorService
    {
        IDataResult<List<InstructorGetDto>> GetAll();
        IDataResult<InstructorGetDto> GetById(Guid id);
        IResult Add(InstructorCreateDto create);
        IResult Update(InstructorUpdateDto update);
        IDataResult<List<InstructorGetDto>> GetAllFilter(int page, int limit);
    }
}
