using Core.Utilities.Results.Abstract;
using Entities.DTOs.Testimonials;

namespace Business.Abstract
{
    public interface ITestimonialService
    {
        IDataResult<List<TestimonialGetDto>> GetAll();
        IResult Add(TestimonialCreateDto create);
    }
}
