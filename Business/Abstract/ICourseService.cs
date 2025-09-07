using Core.Utilities.Results.Abstract;
using Entities.DTOs.Courses;

namespace Business.Abstract
{
    public interface ICourseService
    {
        IDataResult<List<CourseGetDto>> GetAll();
        IDataResult<CourseGetDto> GetById(Guid id);
        IResult Add(CourseCreateDto create);
        IResult Update(CourseUpdateDto update);
        IDataResult<List<CourseGetDto>> GetAllFilter(int page, int limit);
    }
}
