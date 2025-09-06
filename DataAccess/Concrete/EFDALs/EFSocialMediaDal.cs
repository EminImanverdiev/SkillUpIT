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
    public class EFSocialMediaDal : EfEntityRepositoryBase<SocialMedia, AppDbContext>, ISocialMediaDal
    {
        public EFSocialMediaDal(AppDbContext context) : base(context)
        {
        }
    }
}
