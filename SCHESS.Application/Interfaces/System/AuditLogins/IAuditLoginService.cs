using SCHESS.CrossCuttingConcerns.Dtos;
using SCHESS.Models.Systems.AuditLogins.Request;

namespace SCHESS.Application.Interfaces.System.AuditLogins
{
    public interface IAuditLoginService
    {
        Task<ApiResult<int>> AddAsync(AuditLoginRequest request);
    }
}
