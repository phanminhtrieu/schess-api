using SCHESS.CrossCuttingConcerns.Dtos;
using SCHESS.Models.Systems.AppUsers.Request;
using SCHESS.Models.Systems.AppUsers.Dto;

namespace SCHESS.Application.Interfaces.System.AppUsers
{
    public interface IAppUserService
    {
        Task<ApiResult<ClientLoginDto>> Login(LoginRequest request);
    }
}
