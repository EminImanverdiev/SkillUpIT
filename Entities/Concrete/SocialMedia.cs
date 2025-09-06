using Core.Entities.Abstract;
using Entities.Concrete.Common;

namespace Entities.Concrete
{
    public class SocialMedia : BaseEntity, IEntity
    {
        public string Platform { get; set; }
        public string Url { get; set; }        
        public Guid InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}
