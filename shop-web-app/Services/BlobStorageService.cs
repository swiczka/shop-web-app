using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shop_web_app.Helpers;
using shop_web_app.Models;

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

        public async Task<string> UploadFileAsync(IFormFile file, string filename)
        {
            using var stream = file.OpenReadStream();
            var blobClient = _blobContainerClient.GetBlobClient(filename);    
            await blobClient.UploadAsync(stream, overwrite: true);
            var url = blobClient.Uri.ToString();     
            return url;
        }

        public async Task<bool> DeleteFileAsync(string blobName)
        {
            var blobClient = _blobContainerClient.GetBlobClient(blobName);
            return await blobClient.DeleteIfExistsAsync();
        }
    }
}
