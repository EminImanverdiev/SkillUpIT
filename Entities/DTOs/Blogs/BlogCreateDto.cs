using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Blogs
{
    public class BlogCreateDto:IDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile? ImageUrl { get; set; }
    }
}
