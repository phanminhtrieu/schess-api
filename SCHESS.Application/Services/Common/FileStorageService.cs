using SCHESS.Application.Interfaces.Common;
using SCHESS.Infrastructure.Provider.AzureBlob;

namespace SCHESS.Application.Services.Common
{
    public class FileStorageService : IFileStorageService
    {
        public readonly IAzureBlobService _azureBlobService;
        private readonly bool _enableSavingLocally = false;

        public FileStorageService(IAzureBlobService azureBlobService)
        {
            _azureBlobService = azureBlobService;
        }

        public async Task<string> GetFileAsync(string? fileName)
        {
            return await _azureBlobService.GetBlobUri(fileName);
        }
    }
}
