using DataAccess.Abstract;
using DataAccess.Concrete.Database;
using Entities.Concrete;
using Entities.Concrete.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EFDALs
{
    public class EFEventDal : EfEntityRepositoryBase<Event, AppDbContext>, IEventDal
    {
        public EFEventDal(AppDbContext context) : base(context)
        {
        }
    }
}
