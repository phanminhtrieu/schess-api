using SCHESS.Domain.Enums;
using SCHESS.Domain.Interfaces;

namespace SCHESS.Domain.Entity.System
{
    public class EmailSentLog : BaseEntity<int>, IHasDateTracking, IHasPersonTracking
    {
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? FromEmail { get; set; }
        public string? ToEmail { get; set; }
        public EmailFunction EmailFunction { get; set; }
        public bool IsSuccess { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public Guid ModifiedUserId { get; set; }
    }
}
