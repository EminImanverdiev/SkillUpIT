using Core.Entities.Abstract;

namespace Entities.DTOs.SocialMedias
{
    public class SocialMediaGetDto : IDto
    {
        public Guid Id { get; set; }
        public string Platform { get; set; }
        public string Url { get; set; }
        public Guid InstructorId { get; set; }
    }
}