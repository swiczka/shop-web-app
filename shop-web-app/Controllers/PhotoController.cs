using Microsoft.AspNetCore.Mvc;
using shop_web_app.Data;
using shop_web_app.Models;
using shop_web_app.Services;

namespace shop_web_app.Controllers
{
    public class PhotoController : ControllerBase
    {
        private readonly BlobStorageService _blobStorageService;
        private readonly ApplicationDbContext _context;

        public PhotoController(BlobStorageService blobStorageService, ApplicationDbContext context)
        {
            _blobStorageService = blobStorageService;
            _context = context;
        }

        //[HttpPost("upload")]
        //public async Task<IActionResult> Upload(IFormFile file)
        //{
        //    //using var stream = file.OpenReadStream();
        //    ////var url = await _blobStorageService.UploadFileAsync(file.FileName, stream);

        //    //var photo = new Photo { PhotoUrl = url };
        //    //_context.Photos.Add(photo);
        //    //await _context.SaveChangesAsync();

        //    //return Ok(new { Url = url });
        //}

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string blobName)
        {
            var result = await _blobStorageService.DeleteFileAsync(blobName);
            if (result)
            {
                // Opcjonalnie usuń wpis z bazy danych
                var photo = _context.Photos.FirstOrDefault(p => p.PhotoUrl.Contains(blobName));
                if (photo != null)
                {
                    _context.Photos.Remove(photo);
                    await _context.SaveChangesAsync();
                }

                return Ok("Deleted successfully");
            }

            return NotFound("File not found");
        }
    }
}
