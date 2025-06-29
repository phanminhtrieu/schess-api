using SCHESS.CrossCuttingConcerns.Dtos;
using SCHESS.Models.Systems.AppUsers.Request;
using SCHESS.Models.Systems.AppUsers.Dto;
using SCHESS.Domain.Entity.System;

namespace SCHESS.Application.Interfaces.System.AppUsers
{
    public interface IAppUserService
    {
        Task<ApiResult<ClientLoginDto>> Login(LoginRequest request);
        Task<ApiResult<AppUser>> Register(RegisterRequest request);
    }
}
