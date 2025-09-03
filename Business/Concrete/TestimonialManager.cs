using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Testimonials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public IResult Add(TestimonialCreateDto create)
        {
            var addedTestimonial = new Testimonial
            {
                Id = Guid.NewGuid(),
                FullName = create.FullName,
                PositionTitle = create.PositionTitle,
                CompanyName = create.CompanyName,
                AvatarUrl = create.AvatarUrl,
                Quote = create.Quote,
            };
            _testimonialDal.Add(addedTestimonial);
            return new SuccessResult("Testimonail elave edildi");
        }

        public IDataResult<List<TestimonialGetDto>> GetAll()
        {
            var testimonials = _testimonialDal.GetAll();
            var modifiedTestimonials = testimonials.Select(t => new TestimonialGetDto
            {
                Id = t.Id,
                FullName = t.FullName,
                PositionTitle = t.PositionTitle,
                CompanyName = t.CompanyName,
                AvatarUrl = t.AvatarUrl,
                Quote = t.Quote
            }).ToList();
            return new SuccessDataResult<List<TestimonialGetDto>>(modifiedTestimonials, "");
        }
    }
}
