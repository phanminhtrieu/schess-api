﻿namespace SCHESS.Domain.Entity.System
{
    public class AuditLogin : BaseEntity<int>
    {
        public string? UserId { get; set; }
        public string? Email { get; set; }
        public string? UserAgent { get; set; }
        public string? Domain { get; set; }
        public string? IpAddress { get; set; }
        public string? Url { get; set; }
        public string? Notes { get; set; }
        public string? Method { get; set; }
        public bool IsSuccessded { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
