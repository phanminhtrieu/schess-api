using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using SCHESS.Infrastructure.Constants;
using SCHESS.Infrastructure.Provider.Email.Settings;
using System.Net;
using System.Net.Mail;
using System.Runtime;

namespace SCHESS.Infrastructure.Provider.Email
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly MailSettings _settings = new MailSettings();
        //public MailSettings _settings = new MailSettings();

        private readonly bool _isUseMailtrap = true;
        private readonly string _mailtrapHost = "sandbox.smtp.mailtrap.io";
        private readonly string _mailtrapUsername = "4faebb3c04a897";
        private readonly string _mailtrapPassword = "028212d7c47806";

        public SendEmailService(IConfiguration configuration)
        {
            _configuration = configuration;

            InitializeMailSettings();
        }

        private void InitializeMailSettings()
        {
            _settings.Host = _configuration[SystemConstants.EmailConstants.MAIL_SETTINGS_SERVER];
            _settings.Port = int.Parse(_configuration[SystemConstants.EmailConstants.MAIL_SETTINGS_PORT]!);
            _settings.EnableSsl = bool.Parse(_configuration[SystemConstants.EmailConstants.MAIL_SETTINGS_ENABLED_SSL]!);
            _settings.UserName = _configuration[SystemConstants.EmailConstants.MAIL_SETTINGS_USERNAME];
            _settings.Password = _configuration[SystemConstants.EmailConstants.MAIL_SETTINGS_PASSWORD];
            _settings.FromEmail = _configuration[SystemConstants.EmailConstants.MAIL_SETTINGS_FROM_EMAIL];
            _settings.FromName = _configuration[SystemConstants.EmailConstants.MAIL_SETTINGS_FROM_NAME];
            _settings.UseDefaultCredentials = false;
        }

        public MailSettings mailSettings = new MailSettings();

        public Task SendEmailAsync(MailContent content)
        {
            var client = new SmtpClient();

            switch (_isUseMailtrap)
            {
                case true:
                    client = new SmtpClient("live.smtp.mailtrap.io")
                    {
                        UseDefaultCredentials = _settings.UseDefaultCredentials,
                        Port = _settings.Port,
                        EnableSsl = _settings.EnableSsl,
                        Credentials = new NetworkCredential("api", _mailtrapUsername)
                    };

                    client.Send("hello@demomailtrap.co", "phanminhtrieu04@gmail.com", "Hello world", "testbody");
                    break;

                case false:
                    client = new SmtpClient(_settings.Host)
                    {
                        UseDefaultCredentials = _settings.UseDefaultCredentials,
                        Port = _settings.Port,
                        EnableSsl = _settings.EnableSsl,
                        Credentials = new NetworkCredential(_settings.UserName, _settings.Password)
                    };

                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress(_settings.FromEmail, _settings.FromName),
                    };

                    mailMessage.To.Add(content.ToEmail);
                    mailMessage.Body = content.Body;
                    mailMessage.Subject = content.Subject;
                    mailMessage.IsBodyHtml = content.IsHtml;

                    client.Send(mailMessage);

                    break;
            }

            return Task.CompletedTask;
        }

        public Task SendEmailByConfigAsync(MailSettings settings, MailContent content)
        {
            var smtp = new SmtpClient();

            switch (_isUseMailtrap)
            {
                case true:
                    smtp = new SmtpClient
                    {
                        Host = _mailtrapHost,
                        Port = 2525,
                        EnableSsl = true,
                        Credentials = new NetworkCredential(_mailtrapUsername, _mailtrapPassword),
                    };

                    smtp.Send("from@example.com", content.ToEmail!, "Hello world", content.Body);
                    break;

                case false:
                    smtp = new SmtpClient
                    {
                        Host = settings.Host!,
                        Port = settings.Port,
                        EnableSsl = settings.EnableSsl,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(settings.UserName, settings.Password),
                    };

                    MailAddress from = new MailAddress(content.FromEmail!, content.DispalyNameEmail);
                    MailAddress to = new MailAddress(content.ToEmail!);

                    using (var smtpMessage = new MailMessage(from, to))
                    {
                        if (content.EmailCCs != null)
                        {
                            if (content.EmailCCs.Count() > 0)
                            {
                                foreach (var item in content.EmailCCs)
                                {
                                    if (!string.IsNullOrEmpty(item))
                                    {
                                        smtpMessage.CC.Add(new MailAddress(item));
                                    }
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(content.Filename))
                        {
                            smtpMessage.Attachments.Add(new Attachment(content.Filename));
                        }


                        if (content.Files != null && content.Files.Count() > 0)
                        {
                            foreach (var item in content.Files)
                            {
                                smtpMessage.Attachments.Add(new Attachment(item));
                            }
                        }

                        smtpMessage.Subject = content.Subject;
                        smtpMessage.Body = content.Body;
                        smtpMessage.IsBodyHtml = content.IsHtml;
                        smtp.Send(smtpMessage);
                    }

                    break;
            }

            return Task.CompletedTask;
        }
    }
}
