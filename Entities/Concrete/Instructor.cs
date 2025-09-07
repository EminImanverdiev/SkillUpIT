using Core.Entities.Abstract;
using Entities.Concrete.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Instructor:BaseEntity,IEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string ProfileUrl { get; set; }
        public string Bio { get; set; }
        public ICollection<SocialMedia> SocialMedias { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
