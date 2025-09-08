using Core.Entities.Abstract;

namespace Entities.DTOs.Partners
{
    public class PartnerGetDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string WebsiteUrl { get; set; }
    }
}
