using Core.Entities.Abstract;
using Entities.DTOs.SocialMedias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Instructors
{
    public class InstructorUpdateDto:IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string ProfileUrl { get; set; }
        public string Bio { get; set; }
        public ICollection<SocialMediaUpdateDto> SocialMedias { get; set; }

    }
}
