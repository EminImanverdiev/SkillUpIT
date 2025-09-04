using Core.Entities.Abstract;

namespace Entities.DTOs.Events.EventContents
{
    public class EventContentUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public string Tag { get; set; }
        public Guid EventId { get; set; }
    }
}
