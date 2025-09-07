using DataAccess.Abstract;
using DataAccess.Concrete.Database;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EFDALs
{
    public class EFTagDal : EfEntityRepositoryBase<Tag, AppDbContext>, ITagDal
    {
        public EFTagDal(AppDbContext context) : base(context)
        {
        }
    }
}
