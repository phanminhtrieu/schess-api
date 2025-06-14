namespace SCHESS.Models.Systems.AuditLogins.Dto
{
    public class AuditLoginDto
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Email { get; set; }
        public string? UserAgent { get; set; }
        public string? Domain { get; set; }
        public string? IpAddress { get; set; }
        public string? Url { get; set; }
        public string? Notes { get; set; }
        public bool IsSuccessded { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
