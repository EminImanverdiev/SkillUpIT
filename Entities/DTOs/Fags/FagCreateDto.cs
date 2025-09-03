using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Fags
{
    public class FagCreateDto:IDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
