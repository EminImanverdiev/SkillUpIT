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
    internal class EFPartnerDal : EfEntityRepositoryBase<Partner, AppDbContext>, IPartnerDal
    {
        public EFPartnerDal(AppDbContext context) : base(context)
        {
        }
    }
}
