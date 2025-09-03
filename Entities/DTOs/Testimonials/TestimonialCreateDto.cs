using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Testimonials
{
    public class TestimonialCreateDto:IDto
    {
        public string FullName { get; set; }
        public string PositionTitle { get; set; }
        public string CompanyName { get; set; }
        public string AvatarUrl { get; set; }
        public string Quote { get; set; }
    }
}
