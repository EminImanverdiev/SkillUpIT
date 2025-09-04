using DataAccess.Abstract;
using DataAccess.Concrete.Database;
using Entities.Concrete.Events;

namespace DataAccess.Concrete.EFDALs
{
    public class EFEventContentDal : EfEntityRepositoryBase<EventContent, AppDbContext>, IEventContentDal
    {
        public EFEventContentDal(AppDbContext context) : base(context)
        {
        }
    }
}
