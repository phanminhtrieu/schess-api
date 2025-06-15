using SCHESS.Application.Interfaces.Catalog.Emails;
using SCHESS.CrossCuttingConcerns.Dtos;
using SCHESS.Domain.Entity.System;
using SCHESS.Domain.Enums;
using SCHESS.Domain.Repositories;
using SCHESS.Domain.UnitOfWork;
using SCHESS.Infrastructure.Exceptions;
using SCHESS.Infrastructure.Provider.Email;
using SCHESS.Infrastructure.Provider.Email.Settings;
using System.Linq.Expressions;
using static SCHESS.Infrastructure.Constants.SystemConstants;

namespace SCHESS.Application.Services.Catalog.Emails
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IEmailSentLogRepository _emailSentLogRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISendEmailService _sendEmailService;

        public EmailService(IEmailRepository emailRepository,
            IEmailSentLogRepository emailSentLogRepository,
            IUnitOfWork unitOfWork,
            ISendEmailService sendEmailService)
        {
            _emailRepository = emailRepository;
            _emailSentLogRepository = emailSentLogRepository;
            _unitOfWork = unitOfWork;
            _sendEmailService = sendEmailService;
        }

        public async Task<ApiResult<int>> SendEmailConfirmation(string confirmationLink, AppUser user)
        {
            MailSettings setting = new MailSettings();
            MailContent content = new MailContent();
            EmailSentLog emailSentLog = new EmailSentLog();

            bool isUserHasEmail = !string.IsNullOrEmpty(user.Email);
            if (!isUserHasEmail) return new ApiErrorResult<int>(ErrorMessage.USER_DONT_HAVE_EMAIL);
            
            string email = user.Email!;

            var emailDto = await _emailRepository.GetEmailByFunctionType(
                email => email.Function.Equals(EmailFunction.SendEmailConfirmation) && email.EmailSetting!.IsActive == true);

            bool isEmailDtoNull = emailDto is null;
            if (isEmailDtoNull) throw new NotFoundException(ErrorMessage.NOT_FOUND_DATA(nameof(emailDto)));

            setting.UserName = emailDto.EmailSettingUsername;
            setting.Password = emailDto.EmailSettingPassword;
            setting.Port = emailDto.EmailSettingPort != null ? int.Parse(emailDto.EmailSettingPort) : 0;
            setting.FromEmail = emailDto.EmailSettingFromEmail;
            setting.Host = emailDto.EmailSettingHostName;
            setting.EnableSsl = emailDto.EmailSettingIsSsl;
            setting.UseDefaultCredentials = true;

            content.FromEmail = emailDto.EmailSettingFromEmail;
            content.Subject = emailDto.Subject;
            content.Body = emailDto.Body;
            content.DispalyNameEmail = emailDto.EmailSettingDisplayName;
            content.ToEmail = email;
            content.IsHtml = true;

            bool isConfirmationLinkNull = string.IsNullOrEmpty(confirmationLink);
            bool isContentBodyNull = string.IsNullOrEmpty(content.Body);

            if (!isConfirmationLinkNull && !isConfirmationLinkNull)
            {
                content.Body = this.replaceConfirmationLink(confirmationLink, content.Body);
            }

            await _sendEmailService.SendEmailByConfigAsync(setting, content);

            var result = await this.writeEmailLog(content, EmailFunction.SendEmailConfirmation, user.Id);
            if (result == 0) return new ApiErrorResult<int>(ErrorMessage.INTERNAL_SERVER_ERROR);

            return new ApiSuccessResult<int>(result);
        }

        private async Task<int> writeEmailLog(MailContent content, EmailFunction emailFunction, Guid userId)
        {
            var emailSentLog = new EmailSentLog()
            {
                Subject = content.Subject,
                Body = content.Body,
                ToEmail = content.ToEmail,
                FromEmail = content.FromEmail,
                EmailFunction = emailFunction,
                CreatedUserId = userId,
                ModifiedUserId = userId,
                IsSuccess = true
            };

            await _emailSentLogRepository.AddAsync(emailSentLog);

            return await _unitOfWork.SaveChangesAsync();
        }

        private string? replaceConfirmationLink(string confirmationLink, string? body)
        {
            Dictionary<string, string> findAndReplaceValues = new Dictionary<string, string>();
            string replacedContent = MarkupReplacements.CONFIRMATION_LINK;

            findAndReplaceValues.Add(replacedContent, confirmationLink);

            foreach (var kvp in findAndReplaceValues)
            {
                body = body.Replace(kvp.Key, kvp.Value);
            }

            return body;
        }
    }
}
