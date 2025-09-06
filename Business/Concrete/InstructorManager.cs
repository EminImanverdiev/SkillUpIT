using Business.Abstract;
using Core.Entities.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Instructors;
using Entities.DTOs.SocialMedias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InstructorManager : IInstructorService
    {     IInstructorDal _instructorDal;

        public InstructorManager(IInstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }

        public IResult Add(InstructorCreateDto create)
        {
            var instructor = new Entities.Concrete.Instructor
            {
                Id = Guid.NewGuid(),
                Name = create.Name,
                Bio = create.Bio,
                CreatedAt = DateTime.UtcNow,
                Description = create.Description,
                Email = create.Email,
                ProfileUrl = create.ProfileUrl,
                SurName = create.SurName,
                
            };
            foreach (var sm in create.SocialMedias ?? Enumerable.Empty<SocialMediaCreateDto>())
            {
                instructor.SocialMedias.Add(new SocialMedia
                {
                    Id = Guid.NewGuid(),
                    Platform = sm.Platform.Trim(),
                    Url = sm.Url.Trim(),
                    CreatedAt = DateTime.UtcNow
                });
            }
            _instructorDal.Add(instructor);
            return new Result(true, "Instructor added successfully.");
        }

        public IDataResult<List<InstructorGetDto>> GetAll()
        {
            var instructors = _instructorDal.GetAll();
            var instructorDtos = instructors.Select(i => new InstructorGetDto
            {
                Id = i.Id,
                Name = i.Name,
                SurName = i.SurName,
                Email = i.Email,
                Description = i.Description,
                ProfileUrl = i.ProfileUrl,
                Bio = i.Bio,
                SocialMedias = i.SocialMedias?.Select(sm => new SocialMediaGetDto
                {
                    Id = sm.Id,
                    Platform = sm.Platform,
                    Url = sm.Url
                }).ToList() ?? new List<SocialMediaGetDto>()
            }).ToList();
            return new DataResult<List<InstructorGetDto>>(instructorDtos, true, "Instructors retrieved successfully.");

        }

        public IDataResult<List<InstructorGetDto>> GetAllFilter(int page, int limit)
        {
           var instructors = _instructorDal.GetAll().Skip((page - 1) * limit).Take(limit).ToList();
            var instructorDtos = instructors.Select(i => new InstructorGetDto
            {
                Id = i.Id,
                Name = i.Name,
                SurName = i.SurName,
                Email = i.Email,
                Description = i.Description,
                ProfileUrl = i.ProfileUrl,
                Bio = i.Bio,
                SocialMedias = i.SocialMedias?.Select(sm => new SocialMediaGetDto
                {
                    Id = sm.Id,
                    Platform = sm.Platform,
                    Url = sm.Url
                }).ToList() ?? new List<SocialMediaGetDto>()
            }).ToList();
            return new DataResult<List<InstructorGetDto>>(instructorDtos, true, "Instructors retrieved successfully.");
        }

        public IDataResult<InstructorGetDto> GetById(Guid id)
        {
            var instructor = _instructorDal.Get(i => i.Id == id);
            if (instructor == null)
            {
                return new DataResult<InstructorGetDto>(null, false, "Instructor not found.");
            }
            var instructorDto = new InstructorGetDto
            {
                Id = instructor.Id,
                Name = instructor.Name,
                SurName = instructor.SurName,
                Email = instructor.Email,
                Description = instructor.Description,
                ProfileUrl = instructor.ProfileUrl,
                Bio = instructor.Bio,
                SocialMedias = instructor.SocialMedias?.Select(sm => new SocialMediaGetDto
                {
                    Id = sm.Id,
                    Platform = sm.Platform,
                    Url = sm.Url
                }).ToList() ?? new List<SocialMediaGetDto>()
            };
            return new DataResult<InstructorGetDto>(instructorDto, true, "Instructor retrieved successfully.");
        }

        public IResult Update(InstructorUpdateDto update)
        {
            var instructor = _instructorDal.Get(i => i.Id == update.Id);
            if (instructor == null)
            {
                return new Result(false, "Instructor not found.");
            }
            instructor.Name = update.Name;
            instructor.SurName = update.SurName;
            instructor.Email = update.Email;
            instructor.Description = update.Description;
            instructor.ProfileUrl = update.ProfileUrl;
            instructor.Bio = update.Bio;
            instructor.UpdatedAt = DateTime.UtcNow;
            instructor.SocialMedias = update.SocialMedias?.Select(sm => new SocialMedia
            {
                Id = sm.Id != Guid.Empty ? sm.Id : Guid.NewGuid(),
                Platform = sm.Platform.Trim(),
                Url = sm.Url.Trim(),
                CreatedAt = sm.Id != Guid.Empty ? instructor.SocialMedias.FirstOrDefault(existingSm => existingSm.Id == sm.Id)?.CreatedAt ?? DateTime.UtcNow : DateTime.UtcNow
            }).ToList() ?? new List<SocialMedia>();
            _instructorDal.Update(instructor);
            return new Result(true, "Instructor updated successfully.");
        }
    }
}
