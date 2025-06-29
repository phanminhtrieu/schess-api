namespace SCHESS.Models.Systems.AuditLogins.Request
{
    public class AuditLoginRequest
    {
        public string? UserId { get; set; }
        public string? Email { get; set; }
        public string? Notes { get; set; }
        public bool IsSuccessded { get; set; }
    }
}
