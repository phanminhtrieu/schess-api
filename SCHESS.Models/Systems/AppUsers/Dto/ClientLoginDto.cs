using SCHESS.Models.Systems.AppRoles.Dto;

namespace SCHESS.Models.Systems.AppUsers.Dto
{
    public class ClientLoginDto
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? Bio { get; set; }
        public string? Description { get; set; }
        public string? Avatar { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Dob { get; set; }
        public long? XP { get; set; }
        public string? AccessToken { get; set; }

        public IEnumerable<AppRoleDto>? Roles { get; set; }
    }
}
