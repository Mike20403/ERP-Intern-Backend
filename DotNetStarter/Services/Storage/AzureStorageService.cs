using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using DotNetStarter.Services.Configuration;
using Microsoft.Extensions.Options;

namespace DotNetStarter.Services.Storage
{
    public class AzureStorageService : IStorageService
    {
        private readonly AppSettings _appSettings;
        private readonly string _containerName;
        private readonly string _connectionString;

        public AzureStorageService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _connectionString = _appSettings.AzureStorageSettings.ConnectionString;
            _connectionString = _appSettings.AzureStorageSettings.ContainerName;
        }

        public async Task UploadAsync(Stream stream, string blobName, string contentType)
        {
            var blockBlob = await GetBlockBlobAsync(blobName, contentType);

            await blockBlob.UploadAsync(stream);

            if (!string.IsNullOrEmpty(contentType))
            {
                var blobHttpHeaders = new BlobHttpHeaders
                {
                    ContentType = contentType
                };
                await blockBlob.SetHttpHeadersAsync(blobHttpHeaders);
            }
            stream.Close();
        }

        public async Task DeleteAsync(string blobName)
        {
            var blockBlob = await GetBlockBlobAsync(blobName);

            await blockBlob.DeleteIfExistsAsync();
        }

        public async Task DeleteDirectoryAsync(string directoryName)
        {
            var container = await GetBlobContainerAsync();

            await foreach (BlobHierarchyItem blobItem in container.GetBlobsByHierarchyAsync(prefix: directoryName))
            {
                var blobClient = container.GetBlobClient(blobItem.Blob.Name);
                await blobClient.DeleteIfExistsAsync();
            }
        }

        private async Task<BlockBlobClient> GetBlockBlobAsync(string blobName, string contentType = null)
        {
            var container = await GetBlobContainerAsync();
            return container.GetBlockBlobClient(blobName);
        }

        private async Task<BlobContainerClient> GetBlobContainerAsync()
        {
            var blobServiceClient = new BlobServiceClient(_connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
            return containerClient;
        }
    }
}
