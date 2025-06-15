using SCHESS.Domain.Enums;
using SCHESS.Domain.Interfaces;
using SCHESS.Infrastructure.Provider.Email.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCHESS.Domain.Entity.System
{
    public class Email : BaseEntity<int>, IHasDateTracking, IHasPersonTracking
    {
        public string? Code { get; set; }
        public EmailFunction Function { get; set; }
        public string? Title { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }

        public int EmailSettingId { get; set; }
        public virtual EmailSetting? EmailSetting { get; set; }

        public Guid CreatedUserId { get; set; }
        public Guid ModifiedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
