using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.Fags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FagManager : IFagService
    {
        IFagDal _fagDal;

        public FagManager(IFagDal fagDal)
        {
            _fagDal = fagDal;
        }

        public IResult Add(FagDto fag)
        {
            var addedfag = new Fag()
            {
                Id=Guid.NewGuid(),
                Content = fag.Content,
                Title = fag.Title,
            };
            _fagDal.Add(addedfag);
            return new SuccessResult(Messages.XAdded);
        }

        public IDataResult<List<GetFag>> GetAll()
        {
            var fags = _fagDal.GetAll(); 
            var modifiedfags = fags.Select(f => new GetFag
            {
                Id = f.Id,
                Title = f.Title,
                Content = f.Content
            }).ToList();

            return new SuccessDataResult<List<GetFag>>(modifiedfags, "");
        }

        public IDataResult<GetFag> GetById(Guid id)
        {
            var fag = _fagDal.Get(x => x.Id == id); 
            if (fag == null)
                return new ErrorDataResult<GetFag>(null, Messages.XNotFound);

            var modifiedfag = new GetFag
            {
                Id = fag.Id,
                Title = fag.Title,
                Content = fag.Content
            };

            return new SuccessDataResult<GetFag>(modifiedfag, "");
        }
    }
}
