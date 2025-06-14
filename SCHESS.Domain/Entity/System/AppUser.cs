using Microsoft.AspNetCore.Identity;

namespace SCHESS.Domain.Entity.System
{
    public class AppUser : IdentityUser<Guid>
    {
        public string? FullName { get; set; }
        public string? Bio { get; set; }
        public string? Description { get; set; }
        public string? Avatar { set; get; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? ActivateDate { set; get; }
        public DateTime? LastLogin { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { set; get; }
        public bool IsDelete { set; get; }
        public bool IsAnonymous { get; set; }
    }
}
