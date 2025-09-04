using Core.Entities.Abstract;
using Entities.Concrete.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Events
{
    public class EventContent:BaseEntity, IEntity
    {
        public string Tag { get; set; }
        public Event Event { get; set; }
        public Guid EventId { get; set; }
    }
}
