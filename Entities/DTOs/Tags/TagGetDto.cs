using Core.Entities.Abstract;

namespace Entities.DTOs.Tags
{
    public class TagGetDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
