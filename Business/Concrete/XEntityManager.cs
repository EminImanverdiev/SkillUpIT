using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class XEntityManager : IXEntityService
    {
        IXEntityDal _xEntityDal;

        public XEntityManager(IXEntityDal xEntityDal)
        {
            _xEntityDal = xEntityDal;
        }

        [ValidationAspect(typeof(XEntityValidator))]
        public IResult Add(XEntity xEntity)
        {
            ValidationTool.Validate(new ValidationRules.FluentValidation.XEntityValidator(), xEntity);
            _xEntityDal.Add(xEntity);
            return new SuccessResult(Messages.XAdded);
        }

        public IDataResult<List<XEntity>> GetAll()
        {
            return new SuccessDataResult<List<XEntity>>(_xEntityDal.GetAll(), "");
        }

        public IDataResult<XEntity> GetById(Guid id)
        {
            return new SuccessDataResult<XEntity>( _xEntityDal.Get(xe=>xe.Id==id));
        }
    }
}
