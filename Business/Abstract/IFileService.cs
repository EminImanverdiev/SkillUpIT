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
        Task<string> UploadFileAsync(IFormFile file, string folderName);
        Task<List<string>> UploadFilesAsync(List<IFormFile> files, string folderName);
        Task<bool> DeleteFileAsync(string filePath);
        Task<List<string>> UploadVideosAsync(List<IFormFile> videos);

    }
}
