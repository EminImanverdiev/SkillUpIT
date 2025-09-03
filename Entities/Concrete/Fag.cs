using Core.Entities.Abstract;
using Entities.Concrete.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Fag : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
