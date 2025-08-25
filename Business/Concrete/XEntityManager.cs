using Business.Abstract;
using Business.Contants;
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

        public IResult Add(XEntity xEntity)
        {
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
