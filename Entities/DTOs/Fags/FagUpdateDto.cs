using Core.Entities.Abstract;

namespace Entities.DTOs.Fags
{
    public class FagUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
