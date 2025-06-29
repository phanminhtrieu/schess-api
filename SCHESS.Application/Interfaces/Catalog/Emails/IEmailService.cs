using SCHESS.CrossCuttingConcerns.Dtos;
using SCHESS.Domain.Entity.System;

namespace SCHESS.Application.Interfaces.Catalog.Emails
{
    public interface IEmailService
    {
        Task<ApiResult<int>> SendEmailConfirmation(string confirmationLink, AppUser user);
    }
}
