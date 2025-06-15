using SCHESS.Infrastructure.Provider.Email.Settings;

namespace SCHESS.Infrastructure.Provider.Email
{
    public interface ISendEmailService
    {
        Task SendEmailAsync(MailContent emailContent);
        Task SendEmailByConfigAsync(MailSettings emailSettings, MailContent content);
    }
}
