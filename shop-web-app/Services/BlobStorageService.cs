using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shop_web_app.Helpers;
using shop_web_app.Models;

namespace shop_web_app.Services
{
    public class BlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public readonly AzureBlobStorageSettings _settings;

        public BlobStorageService(IOptions<AzureBlobStorageSettings> blobStorageSettings)
        {
            _settings = blobStorageSettings.Value;
            _blobServiceClient = new BlobServiceClient(_settings.ConnectionString);
        }

        private BlobContainerClient GetBlobContainerClient(string containerName)
        {
            return _blobServiceClient.GetBlobContainerClient(containerName);
        }

        public async Task<string> UploadFileAsync(IFormFile file, string filename, string container)
        {
            if (container != null &&
                (container.Equals(_settings.PhotosContainerName) || container.Equals(_settings.ModelsContainerName)))
            {
                using var stream = file.OpenReadStream();
                var blobClient = GetBlobContainerClient(container).GetBlobClient(filename);
                await blobClient.UploadAsync(stream, overwrite: true);
                var url = blobClient.Uri.ToString();
                return url;
            }
            else return null;
        }

        public async Task<bool> DeleteFileAsync(string blobName, string container)
        {
            if (container != null &&
                (container.Equals(_settings.PhotosContainerName) || container.Equals(_settings.ModelsContainerName)))
            {
                var blobClient = GetBlobContainerClient(container).GetBlobClient(blobName);
                return await blobClient.DeleteIfExistsAsync();
            }
            else return false;
        }
    }
}
