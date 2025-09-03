using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ContactBlocks
{
    public class ContactBlockCreateDto:IDto
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
    }
}
