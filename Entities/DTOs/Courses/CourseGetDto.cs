using Core.Entities.Abstract;

namespace Entities.DTOs.Courses
{
    public class CourseGetDto : IDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LessonCount { get; set; }
        public int VideoCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Url { get; set; }
        public Guid InstructorId { get; set; }
    }
}
