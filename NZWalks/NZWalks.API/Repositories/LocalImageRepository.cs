using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly NZWalksDbContext nZWalksDbContext;
        private readonly IHttpContextAccessor httpContextAccessor;


        public LocalImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, NZWalksDbContext nZWalksDbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.nZWalksDbContext = nZWalksDbContext;
        }
        /*
        public async Task<Image> Upload(Image image)
        {
            var localFilePath = Path.Combine(
                webHostEnvironment.ContentRootPath,
                "Images",
                image.FileName,
                image.FileExtension
            );

            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            //https:localhost:1234/images/images.jpg


            //var urlFilePath = $"{HttpContextAccessor.HttpContext.Request.Scheme}://{HttpContextAccessor.HttpContext.Request.Host}{HttpContextAccessor.HttpContext.Request.Path}/Images/{image.FileName}{image.FileExtension}";
            var request = httpContextAccessor.HttpContext.Request;

            var urlFilePath = $"{request.Scheme}://{request.Host}/Images/{image.FileName}{image.FileExtension}";
            image.FilePath = urlFilePath;

            //Add Image to the Images Table

            await nZWalksDbContext.Images.AddAsync(image);
            await nZWalksDbContext.SaveChangesAsync();
            return image;
        }
        */
        public async Task<Image> Upload(Image image)
        {
            var imagesFolderPath = Path.Combine(
                webHostEnvironment.ContentRootPath,
                "Images"
            );

            // Ensure Images folder exists
            if (!Directory.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }

            // Generate unique filename (BEST PRACTICE)
            var fileName = Guid.NewGuid().ToString();
            var fileExtension = Path.GetExtension(image.File.FileName);

            var fullFileName = fileName + fileExtension;

            var localFilePath = Path.Combine(imagesFolderPath, fullFileName);

            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            // Build URL
            var request = httpContextAccessor.HttpContext.Request;
            var urlFilePath = $"{request.Scheme}://{request.Host}/Images/{fullFileName}";

            image.FileName = fileName;
            image.FileExtension = fileExtension;
            image.FilePath = urlFilePath;

            await nZWalksDbContext.Images.AddAsync(image);
            await nZWalksDbContext.SaveChangesAsync();

            return image;
        }
    }
}