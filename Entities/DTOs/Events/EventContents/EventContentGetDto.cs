using Core.Entities.Abstract;

namespace Entities.DTOs.Events.EventContents
{
    public class EventContentGetDto : IDto
    {
        public Guid Id { get; set; }
        public string Tag { get; set; }
        public Guid EventId { get; set; }
    }
}
