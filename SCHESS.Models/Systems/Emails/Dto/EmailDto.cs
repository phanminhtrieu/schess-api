namespace SCHESS.Models.Systems.Emails.Dto
{
    public class EmailDto
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public int FunctionId { get; set; }
        public string? Title { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public int EmailSettingId { get; set; }
        public string? EmailSettingHostName { get; set; }
        public string? EmailSettingIp { get; set; }
        public string? EmailSettingUsername { get; set; }
        public string? EmailSettingFromEmail { get; set; }
        public string? EmailSettingPassword { get; set; }
        public string? EmailSettingPort { get; set; }
        public string? EmailSettingDisplayName { get; set; }
        public bool EmailSettingIsActive { get; set; }
        public bool EmailSettingIsSsl { get; set; }

        public Guid CreatedUserId { get; set; }
        public Guid ModifiedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
