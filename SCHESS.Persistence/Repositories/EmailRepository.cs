using Microsoft.EntityFrameworkCore;
using SCHESS.Domain.Entity.System;
using SCHESS.Domain.Repositories;
using SCHESS.Models.Systems.Emails.Dto;
using SCHESS.Persistence.UnitOfWork;
using System.Linq.Expressions;

namespace SCHESS.Persistence.Repositories
{
    public class EmailRepository : Repository<Email>, IEmailRepository
    {
        private readonly AppDbContext _context;

        public EmailRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<EmailDto> GetEmailByFunctionType(Expression<Func<Email, bool>> filter)
        {
            var query = _context.Emails.Include(x => x.EmailSetting).AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var emailDto = await query.Select(x => new EmailDto()
            {
                EmailSettingUsername = x.EmailSetting.Username,
                EmailSettingPassword = x.EmailSetting.Password,
                EmailSettingPort = x.EmailSetting.Port,
                EmailSettingFromEmail = x.EmailSetting.FromEmail,
                EmailSettingHostName = x.EmailSetting.HostName,
                EmailSettingIp = x.EmailSetting.Ip,
                EmailSettingIsSsl = x.EmailSetting.IsSsl,
                Subject = x.Subject,
                Body = x.Body,
                EmailSettingDisplayName = x.EmailSetting.DisplayName
            }).FirstOrDefaultAsync();

            return emailDto;
        }
    }
}
