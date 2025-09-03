using Core.Entities.Abstract;

namespace Entities.DTOs.ContactBlocks
{
    public class ContactBlockUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
    }
}
