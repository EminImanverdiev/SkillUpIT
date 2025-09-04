using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete.File;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

public sealed class FileUploadOptions
{
    public int MaxImageSizeMb { get; set; } = 10;
    public int MaxVideoSizeMb { get; set; } = 200;
    public string[] AllowedImageTypes { get; set; } = Array.Empty<string>();
    public string[] AllowedVideoTypes { get; set; } = Array.Empty<string>();
    public bool UseDateFolders { get; set; } = true;
    public string ImageFolder { get; set; } = "images";
    public string VideoFolder { get; set; } = "videos";
}

public class FileManager : IFileService
{
    private readonly FileUploadOptions _opt;
    private readonly string _rootPath;

    public FileManager(string rootPath, IOptions<FileUploadOptions> opt)
    {
        _rootPath = rootPath ?? throw new ArgumentNullException(nameof(rootPath));
        _opt = (opt ?? throw new ArgumentNullException(nameof(opt))).Value;
    }

    public async Task<FileUploadResult> UploadAsync(IFormFile file, FileCategory cat, string folder)
    {
        if (file is null || file.Length == 0)
            throw new ArgumentException("File is empty");

        Validate(file, cat);

        if (_opt.UseDateFolders)
        {
            var today = DateTime.UtcNow;
            folder = Path.Combine(folder, $"{today:yyyy}", $"{today:MM}", $"{today:dd}");
        }

        var uploads = Path.Combine(_rootPath, folder);
        Directory.CreateDirectory(uploads);

        var ext = Path.GetExtension(file.FileName);
        var safeName = $"{Guid.NewGuid()}{ext}";
        var fullPath = Path.Combine(uploads, safeName);

        using (var fs = new FileStream(fullPath, FileMode.Create))
            await file.CopyToAsync(fs);

        var url = "/" + Path.Combine(folder, safeName).Replace("\\", "/");

        return new FileUploadResult
        {
            Url = url,
            FileName = safeName,
            ContentType = file.ContentType,
            SizeBytes = file.Length
        };
    }

    public async Task<IReadOnlyList<FileUploadResult>> UploadManyAsync(IEnumerable<IFormFile> files, FileCategory cat, string folder)
    {
        var list = new List<FileUploadResult>();
        foreach (var f in files.Where(x => x != null && x.Length > 0))
        {
            try
            {
                var r = await UploadAsync(f, cat, folder);
                list.Add(r);
            }
            catch
            {
            }
        }
        return list;
    }

    public Task DeleteAsync(string urlOrPath)
    {
        if (string.IsNullOrWhiteSpace(urlOrPath)) return Task.CompletedTask;

        var relative = urlOrPath.StartsWith("/")
            ? urlOrPath.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString())
            : urlOrPath;

        var full = Path.Combine(_rootPath, relative);
        if (File.Exists(full))
            File.Delete(full);

        return Task.CompletedTask;
    }

    private void Validate(IFormFile file, FileCategory cat)
    {
        if (cat == FileCategory.Image)
        {
            if (!_opt.AllowedImageTypes.Contains(file.ContentType, StringComparer.OrdinalIgnoreCase))
                throw new InvalidOperationException($"Image content type not allowed: {file.ContentType}");

            var max = _opt.MaxImageSizeMb * 1024L * 1024L;
            if (file.Length > max)
                throw new InvalidOperationException($"Image too large. Max: {_opt.MaxImageSizeMb} MB");
        }
        else if (cat == FileCategory.Video)
        {
            if (!_opt.AllowedVideoTypes.Contains(file.ContentType, StringComparer.OrdinalIgnoreCase))
                throw new InvalidOperationException($"Video content type not allowed: {file.ContentType}");

            var max = _opt.MaxVideoSizeMb * 1024L * 1024L;
            if (file.Length > max)
                throw new InvalidOperationException($"Video too large. Max: {_opt.MaxVideoSizeMb} MB");
        }
    }
}
