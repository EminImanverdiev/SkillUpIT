using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Database;
using Microsoft.EntityFrameworkCore; // ToList, AsNoTracking
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EFDALs
{
    public class EfUserDal : EfEntityRepositoryBase<User, AppDbContext>, IUserDal
    {
        private readonly AppDbContext _context;

        public EfUserDal(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            var result =
                from oc in _context.OperationClaims.AsNoTracking()
                join uoc in _context.UserOperationClaims.AsNoTracking()
                    on oc.Id equals uoc.OperationClaimId
                where uoc.UserId == user.Id
                select new OperationClaim { Id = oc.Id, Name = oc.Name };

            return result.ToList();
        }
    }
}
