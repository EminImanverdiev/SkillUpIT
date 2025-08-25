using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.XEntities
{
    public class Get:IDto
    {
            public Guid Id { get; set; }
            public string XName { get; set; }
    }
}
