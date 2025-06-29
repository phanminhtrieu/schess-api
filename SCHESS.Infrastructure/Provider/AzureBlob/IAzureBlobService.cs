using SCHESS.CrossCuttingConcerns.Entity;
using SCHESS.Infrastructure.Provider.AzureBlob.Models;

namespace SCHESS.Infrastructure.Provider.AzureBlob
{
    public interface IAzureBlobService
    {
        //Task<bool> Upload(string? fileName, Stream stream);

        //Task<bool> Upload(string? fileName, byte[] bufferBytes);

        //Task<byte[]> Download(BlobStorage blob);

        //Task<byte[]> Download(string? fileName);

        //Task<byte[]?> DownloadOrDefault(string? fileName);

        //Task<bool> Delete(string? fileName);

        Task<string> GetBlobUri<T>(T blobEntity) where T : IBlob;

        Task<string> GetBlobUri(string? fileName);

        //Task<string> GetDownloadUrl<T>(T blobEntity) where T : IBlob;

        //Task<string> GetDownloadUrl<T>(T blobEntity, string? fileName) where T : IBlob;
    }
}
