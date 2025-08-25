using DataAccess.Abstract;
using DataAccess.Concrete.Database;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFXEntityDal : EfEntityRepositoryBase<XEntity, AppDbContext>, IXEntityDal
    {
        public EFXEntityDal(AppDbContext context) : base(context)
        {
        }
    }
}
