using Core.Entities.Abstract;
using Entities.Concrete.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Course : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int LessonCount { get; set; }
        public int VideoCount { get; set; }
        public string Url { get; set; }
        public Guid InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<Tag> Tags { get; set; }

    }
}
