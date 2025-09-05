using Core.Utilities.Results.Abstract;
using Entities.DTOs.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService
    {
        IDataResult<List<BlogGetDto>> GetAll();
        IDataResult<BlogGetDto> GetById(Guid id);
        IResult Add(BlogCreateDto create);
        IResult Update(BlogUpdateDto update);
        IDataResult<List<BlogGetDto>> GetAllFilter(int page, int limit);

    }
}
