using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Courses
{
    public class CourseCreateDto:IDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int LessonCount { get; set; }
        public int VideoCount { get; set; }
        public string Url { get; set; }
        public Guid InstructorId { get; set; }
    }
}
