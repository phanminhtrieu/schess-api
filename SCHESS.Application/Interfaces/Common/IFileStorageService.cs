namespace SCHESS.Application.Interfaces.Common
{
    public interface IFileStorageService
    {
        Task<string> GetFileAsync(string? fileName);
    }
}
