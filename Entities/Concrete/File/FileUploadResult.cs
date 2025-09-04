using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.File
{
    public sealed class FileUploadResult
    {
        public string Url { get; init; } = default!;
        public string FileName { get; init; } = default!;
        public string ContentType { get; init; } = default!;
        public long SizeBytes { get; init; }
    }
    public enum FileCategory { Image, Video }

}
