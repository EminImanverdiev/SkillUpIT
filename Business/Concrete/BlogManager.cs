using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Blogs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        private readonly IFileService _fileService; 

        public BlogManager(IBlogDal blogDal, IFileService fileService)
        {
            _blogDal = blogDal;
            _fileService = fileService;
        }

        public IResult Add(BlogCreateDto create)
        {
            try
            {
                string? imageUrl = null;
                if (create.ImageUrl != null && create.ImageUrl.Length > 0)
                {
                    imageUrl = _fileService.UploadFileAsync(create.ImageUrl, "images").GetAwaiter().GetResult();
                }

                var addedBlog = new Blog
                {
                    Id = Guid.NewGuid(),
                    Title = create.Title,
                    Content = create.Content,
                    ImageUrl = imageUrl,
                    CreatedAt = DateTime.UtcNow
                };

                _blogDal.Add(addedBlog);

                return new SuccessResult("Blog added successfully.");
            }
            catch (DbUpdateException ex)
            {
                var inner = ex.InnerException?.Message ?? ex.Message;
                return new ErrorResult($"DB error: {inner}");
            }

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

        public IDataResult<List<BlogGetDto>> GetAllFilter(int page, int limit)
        {
            var blogs = _blogDal.GetAllFilter(
                            page, limit,
                            filter: null,
                            orderBy: q => q.OrderByDescending(b => b.CreatedAt)
                        )
                        .Select(b => new BlogGetDto
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Content = b.Content,
                            ImageUrl = b.ImageUrl
                        })
                        .ToList();

            return new SuccessDataResult<List<BlogGetDto>>(blogs, "Paged blogs retrieved.");
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
