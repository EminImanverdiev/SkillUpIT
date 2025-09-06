using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("nam/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var result = await _fileService.UploadFileAsync(file, "images");
            return Ok(result);
        }

        [HttpPost("upload-images")]
        public async Task<IActionResult> UploadImages([FromForm] List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return BadRequest("Heç bir fayl seçilməyib!");

            var result = await _fileService.UploadFilesAsync(files, "images");
            return Ok(result);
        }
        [RequestSizeLimit(100_000_000)]
        [HttpPost("upload-video")]
        public async Task<IActionResult> UploadVideo(IFormFile file)
        {
            var result = await _fileService.UploadFileAsync(file, "videos");
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteFile(string filePath)
        {
            var result = await _fileService.DeleteFileAsync(filePath);
            return result ? Ok("Deleted") : NotFound("File not found");
        }
        [HttpPost("upload-videos")]
        [RequestSizeLimit(500_000_000)] // 500 MB (çoxlu video üçün)
        public async Task<IActionResult> UploadVideos([FromForm] List<IFormFile> videos)
        {
            if (videos == null || videos.Count == 0)
                return BadRequest("Heç bir video seçilməyib!");

            var result = await _fileService.UploadVideosAsync(videos);
            return Ok(result);
        }

    }
}
