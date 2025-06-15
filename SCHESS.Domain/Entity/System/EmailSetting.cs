using SCHESS.Domain.Interfaces;

namespace SCHESS.Domain.Entity.System
{
    public class EmailSetting : BaseEntity<int>, IHasDateTracking, IHasPersonTracking
    {
        public string? HostName { get; set; }
        public string? Ip { get; set; }
        public string? Username { get; set; }
        public string? FromEmail { get; set; }
        public string? Password { get; set; }
        public string? Port { get; set; }
        public string? DisplayName { get; set; }
        public bool IsActive { get; set; }
        public bool IsSsl { get; set; }

        public Guid CreatedUserId { get; set; }
        public Guid ModifiedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Email>? Emails { get; set; }
    }
}
