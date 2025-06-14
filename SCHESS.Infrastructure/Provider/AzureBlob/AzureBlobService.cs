using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using SCHESS.CrossCuttingConcerns.Entity;

namespace SCHESS.Infrastructure.Provider.AzureBlob
{
    public class AzureBlobService : IAzureBlobService
    {
        private readonly CloudBlobClient Client;
        private readonly IConfiguration _configuration;
        private readonly string _blobContainer;

        public AzureBlobService(IConfiguration configuration)
        {
            try
            {
                var storageAccount = CloudStorageAccount.Parse(configuration.GetConnectionString("AzureStorage"));

                Client = storageAccount.CreateCloudBlobClient();

                _configuration = configuration;

                var azureEnvironment = _configuration.GetSection(key: "AzureEnvironment");
                var azureEnvironmentName = azureEnvironment.GetSection("Name").Value;
                var azureEnvironmentContainer = azureEnvironment.GetSection("Container").Value;

                _blobContainer = string.Concat(azureEnvironmentName, "-", azureEnvironmentContainer).ToLower();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Problem witch azure storage account", ex);
            }
        }

        public async Task<string> GetBlobUri<T>(T blobEntity) where T : IBlob
        {
            var container = Client.GetContainerReference(_blobContainer);

            var blob = container.GetBlockBlobReference($"{blobEntity.Id}{blobEntity.ExtensionWithDot}");

            return await blob.ExistsAsync() ? blob.Uri.AbsoluteUri : null;
        }

        public async Task<string> GetBlobUri(string? fileName)
        {
            var container = Client.GetContainerReference(_blobContainer);

            var blob = container.GetBlockBlobReference(fileName);

            return await blob.ExistsAsync() ? blob.Uri.AbsoluteUri : null;
        }
    }
}
