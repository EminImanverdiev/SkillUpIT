using Business.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FileManager : IFileService
    {
        private readonly string _rootPath;

        public FileManager()
        {
            _rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        }

        public async Task<string> UploadFileAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty!");

            string folderPath = Path.Combine(_rootPath, folderName);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string fileExtension = Path.GetExtension(file.FileName);
            string fileName = $"{Guid.NewGuid()}{fileExtension}";
            string filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/{folderName}/{fileName}";
        }

        public async Task<List<string>> UploadFilesAsync(List<IFormFile> files, string folderName)
        {
            var uploadedFiles = new List<string>();

            foreach (var file in files)
            {
                var filePath = await UploadFileAsync(file, folderName);
                uploadedFiles.Add(filePath);
            }

            return uploadedFiles;
        }

        public async Task<bool> DeleteFileAsync(string filePath)
        {
            string fullPath = Path.Combine(_rootPath, filePath.TrimStart('/'));

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

        public Task<List<string>> UploadVideosAsync(List<IFormFile> videos)
        {
            throw new NotImplementedException();
        }
    }
}
