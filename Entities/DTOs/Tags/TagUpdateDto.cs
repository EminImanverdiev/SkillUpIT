using Core.Entities.Abstract;

namespace Entities.DTOs.Tags
{
    public class TagUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
