using Core.Entities.Abstract;
using Entities.Concrete.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ContactBlock: BaseEntity,IEntity
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }

    }
}
