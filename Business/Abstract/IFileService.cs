using Entities.Concrete.File;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFileService
    {
        Task<FileUploadResult> UploadAsync(IFormFile file, FileCategory cat, string folder);
        Task<IReadOnlyList<FileUploadResult>> UploadManyAsync(IEnumerable<IFormFile> files, FileCategory cat, string folder);
        Task DeleteAsync(string urlOrPath);
    }
}
