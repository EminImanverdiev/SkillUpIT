using Core.Entities.Abstract;
using Entities.DTOs.SocialMedias;

namespace Entities.DTOs.Instructors
{
    public class InstructorGetDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string ProfileUrl { get; set; }
        public string Bio { get; set; }
        public ICollection<SocialMediaGetDto> SocialMedias { get; set; }

    }
}
