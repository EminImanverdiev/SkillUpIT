using Core.Entities.Abstract;
using Entities.Concrete.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Events.EventContents
{
    public class EventContentCreateDto:IDto
    {
        public string Tag { get; set; }
        public Guid EventId { get; set; }
    }
}
