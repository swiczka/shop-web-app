using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using shop_web_app.Helpers;

namespace shop_web_app.Services
{
    public class BlobStorageService
    {
        private readonly BlobContainerClient _blobContainerClient;

        public BlobStorageService(IOptions<AzureBlobStorageSettings> blobStorageSettings)
        {
            var settings = blobStorageSettings.Value;
            var blobServiceClient = new BlobServiceClient(settings.ConnectionString);
            _blobContainerClient = blobServiceClient.GetBlobContainerClient(settings.ContainerName);
        }

        public async Task<string> UploadFileAsync(string blobName, Stream fileStream)
        {
            var blobClient = _blobContainerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(fileStream, overwrite: true);

            return blobClient.Uri.ToString();
        }

        public async Task<bool> DeleteFileAsync(string blobName)
        {
            var blobClient = _blobContainerClient.GetBlobClient(blobName);
            return await blobClient.DeleteIfExistsAsync();
        }
    }
}
