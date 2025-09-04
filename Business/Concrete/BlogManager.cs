using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public IResult Add(BlogCreateDto create)
        {
            var addedBlog = new Blog
            {
                Id = Guid.NewGuid(),
                Title = create.Title,
                Content = create.Content,
                ImageUrl = create.ImageUrl,
                CreatedAt = DateTime.UtcNow
            };
            _blogDal.Add(addedBlog);
            return new SuccessResult("Blog added successfully.");

        }

        public IDataResult<List<BlogGetDto>> GetAll()
        {
            var blogs=_blogDal.GetAll();
            var modifiedBlogs = blogs.Select(b => new BlogGetDto
            {
                Id = b.Id,
                Title = b.Title,
                Content = b.Content,
                ImageUrl = b.ImageUrl
            }).ToList();
            return new SuccessDataResult<List<BlogGetDto>>(modifiedBlogs, "Blogs retrieved successfully.");
        }

        public IDataResult<BlogGetDto> GetById(Guid id)
        {
            var blog = _blogDal.Get(b => b.Id == id);
            if (blog == null)
                return new ErrorDataResult<BlogGetDto>("Blog not found.");
            var blogDto = new BlogGetDto
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                ImageUrl = blog.ImageUrl
            };
            return new SuccessDataResult<BlogGetDto>(blogDto, "Blog retrieved successfully.");
        }

        public IResult Update(BlogUpdateDto update)
        {
            var blog = _blogDal.Get(b => b.Id == update.Id);
            if (blog == null)
                return new ErrorResult("Blog not found.");
            blog.Title = update.Title;
            blog.Content = update.Content;
            blog.ImageUrl = update.ImageUrl;
            blog.UpdatedAt = DateTime.UtcNow;
            _blogDal.Update(blog);
            return new SuccessResult("Blog updated successfully.");
        }
    }
}
