using Business.Abstract;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.DTOs.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public IResult Add(CourseCreateDto create)
        {
            var course = new Entities.Concrete.Course
            {
                Id = Guid.NewGuid(),
                Title = create.Title,
                Description = create.Description,
                LessonCount = create.LessonCount,
                VideoCount = create.VideoCount,
                Url = create.Url,
                InstructorId = create.InstructorId,
                CreatedAt = DateTime.UtcNow,
            };
            _courseDal.Add(course);
            return new Core.Utilities.Results.Concrete.SuccessResult("Course added successfully");
        }

        public IDataResult<List<CourseGetDto>> GetAll()
        {
            var courses = _courseDal.GetAll();
            var courseGetDtos = courses.Select(c => new CourseGetDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                LessonCount = c.LessonCount,
                VideoCount = c.VideoCount,
                Url = c.Url,
                InstructorId = c.InstructorId,
                CreatedAt = c.CreatedAt,
            }).ToList();
            return new Core.Utilities.Results.Concrete.SuccessDataResult<List<CourseGetDto>>(courseGetDtos, "Courses retrieved successfully");
        }

        public IDataResult<List<CourseGetDto>> GetAllFilter(int page, int limit)
        {
            var courses = _courseDal.GetAll().Skip((page - 1) * limit).Take(limit).ToList();
            var courseGetDtos = courses.Select(c => new CourseGetDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                LessonCount = c.LessonCount,
                VideoCount = c.VideoCount,
                Url = c.Url,
                InstructorId = c.InstructorId,
                CreatedAt = c.CreatedAt,
            }).ToList();
            return new Core.Utilities.Results.Concrete.SuccessDataResult<List<CourseGetDto>>(courseGetDtos, "Courses retrieved successfully");
        }

        public IDataResult<CourseGetDto> GetById(Guid id)
        {
           var course = _courseDal.Get(c => c.Id == id);
            if (course == null)
            {
                return new Core.Utilities.Results.Concrete.ErrorDataResult<CourseGetDto>(null, "Course not found");
            }
            var courseGetDto = new CourseGetDto
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                LessonCount = course.LessonCount,
                VideoCount = course.VideoCount,
                Url = course.Url,
                InstructorId = course.InstructorId,
                CreatedAt = course.CreatedAt,
            };
            return new Core.Utilities.Results.Concrete.SuccessDataResult<CourseGetDto>(courseGetDto, "Course retrieved successfully");
        }

        public IResult Update(CourseUpdateDto update)
        {
           var course = _courseDal.Get(c => c.Id == update.Id);
            if (course == null)
            {
                return new Core.Utilities.Results.Concrete.ErrorResult("Course not found");
            }
            course.Title = update.Title;
            course.Description = update.Description;
            course.LessonCount = update.LessonCount;
            course.VideoCount = update.VideoCount;
            course.Url = update.Url;
            course.InstructorId = update.InstructorId;
            _courseDal.Update(course);
            return new Core.Utilities.Results.Concrete.SuccessResult("Course updated successfully");
        }
    }
}
