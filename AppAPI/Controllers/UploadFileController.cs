using AppAPI.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        public readonly IFileService fileService;
        public UploadFileController(IFileService fileService)
        {
            this.fileService = fileService;
        }
        [Route("upload")]
        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            var uploadFile = await fileService.UploadFile(file);
            if (uploadFile == null)
            {
                return BadRequest("Error");
            }
            else
            {
                return Ok(uploadFile);
            }
        }
    }
}
