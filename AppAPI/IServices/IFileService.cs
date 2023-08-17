using AppData.Models;

namespace AppAPI.IServices
{
    public interface IFileService
    {
        Task<UploadedFile> UploadFile(IFormFile file);
    }
}
