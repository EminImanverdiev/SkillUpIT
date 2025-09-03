using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
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

        public IResult Add(FagCreateDto create)
        {
            var addedfag = new Fag()
            {
                Id=Guid.NewGuid(),
                Content = create.Content,
                Title = create.Title,
                CreatedAt = DateTime.UtcNow,
            };
            _fagDal.Add(addedfag);
            return new SuccessResult(Messages.XAdded);
        }

        public IDataResult<List<FagGetDto>> GetAll()
        {
            var fags = _fagDal.GetAll(); 
            var modifiedfags = fags.Select(f => new FagGetDto
            {
                Id = f.Id,
                Title = f.Title,
                Content = f.Content
            }).ToList();

            return new SuccessDataResult<List<FagGetDto>>(modifiedfags, "");
        }

        public IDataResult<FagGetDto> GetById(Guid id)
        {
            var fag = _fagDal.Get(x => x.Id == id); 
            if (fag == null)
                return new ErrorDataResult<FagGetDto>(null, Messages.XNotFound);

            var modifiedfag = new FagGetDto
            {
                Id = fag.Id,
                Title = fag.Title,
                Content = fag.Content
            };

            return new SuccessDataResult<FagGetDto>(modifiedfag, "");
        }

        public IResult Update(FagUpdateDto update)
        {
           
            var existingFag = _fagDal.Get(x => x.Id == update.Id);
            if (existingFag == null)
            {
                return new ErrorResult("Fag tapilmadi");
            }
            existingFag.Title = update.Title;
            existingFag.Content = update.Content;
            existingFag.UpdatedAt = DateTime.UtcNow;
            _fagDal.Update(existingFag);
            return new SuccessDataResult<FagGetDto>("Ugurla yenilendi");
        }

    }
}
