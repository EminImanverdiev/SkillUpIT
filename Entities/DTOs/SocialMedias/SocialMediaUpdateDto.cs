using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.SocialMedias
{
    public class SocialMediaUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public string Platform { get; set; }
        public string Url { get; set; }
        public Guid InstructorId { get; set; }
    }
}