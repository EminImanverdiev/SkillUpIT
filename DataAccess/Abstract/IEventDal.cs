using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEventDal : IEntityRepository<Event>
    {
    }
}
