using SCHESS.Domain.Entity.System;
using SCHESS.Domain.UnitOfWork;
using SCHESS.Models.Systems.Emails.Dto;
using System.Linq.Expressions;

namespace SCHESS.Domain.Repositories
{
    public interface IEmailRepository : IRepository<Email>
    {
        Task<EmailDto> GetEmailByFunctionType(Expression<Func<Email, bool>> filter);
    }
}
