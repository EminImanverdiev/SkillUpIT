using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Log
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime TimestampUtc { get; set; } = DateTime.UtcNow;

        public string Level { get; set; } = "Information"; // Information, Warning, Error
        public string Message { get; set; } = default!;
        public string? Exception { get; set; }

        public string Method { get; set; } = default!;
        public string Path { get; set; } = default!;
        public int StatusCode { get; set; }
        public long DurationMs { get; set; }
        public string? QueryString { get; set; }
        public string? UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? RemoteIp { get; set; }

        public string? TraceId { get; set; }
        public string? CorrelationId { get; set; }

        public string? SourceContext { get; set; }
        public string? RequestBody { get; set; }
        public string? ResponseBody { get; set; }
    }
}
