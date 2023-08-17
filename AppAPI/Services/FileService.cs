using AppAPI.IServices;
using AppData.Models;

namespace AppAPI.Services
{
    public class FileService : IFileService
    {
        public readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment environment;
        public FileService(IWebHostEnvironment environment)
        {
            _dbContext = new AppDbContext();
            this.environment = environment;
        }
        public async Task<UploadedFile> UploadFile(IFormFile file)
        {
            if (file == null)
            {
                return null;
            }
            // Luu file vao thu muc wwwroot/uploads
            var filePath = Path.Combine(this.environment.ContentRootPath, "wwwroot", "uploads", file.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            // Doc content cua file
            byte[] fileContent;
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                using (var memoryStream = new MemoryStream())
                {
                    await fileStream.CopyToAsync(memoryStream);
                    fileContent = memoryStream.ToArray();
                }
            }
            // Luu thong tin file vao database
            var uploadFile = new UploadedFile()
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                FileContent = fileContent
            };
            this._dbContext.uploadedFiles.Add(uploadFile);
            await this._dbContext.SaveChangesAsync();
            return uploadFile;
        }
    }
}
