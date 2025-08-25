using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Business.Abstract
{
    public interface IXEntityService
    {
        IDataResult<List<XEntity>> GetAll();
        IDataResult<XEntity> GetById(Guid id);
        IResult Add(XEntity xEntity);
    }
}
