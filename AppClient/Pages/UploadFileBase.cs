using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;

namespace AppClient.Pages
{
    public class UploadFileBase : ComponentBase
    {
        public IBrowserFile file { get; set; }
        public string uploadMessage { get; set; } = string.Empty;
        private string[] allowedFileTypes = { ".txt", ".png", ".xls" };

        [Inject]
        public HttpClient httpClient { get; set; }
        public async Task HandleFileChange(InputFileChangeEventArgs e)  
        {
            file = e.File;
            uploadMessage = string.Empty;
        }
        public async Task UploadFile()
        {
            if (file == null)
            {
                uploadMessage = "Vui lòng chọn tệp tải lên.";
                return;
            }

            var fileExtension = Path.GetExtension(file.Name);
            if (!allowedFileTypes.Contains(fileExtension))
            {
                uploadMessage = "File không đúng định dạng: " + string.Join(", ", allowedFileTypes) + " ,vui lòng chọn lại.";
                return;
            }
            var content = new MultipartFormDataContent();
            var streamContent = new StreamContent(file.OpenReadStream(file.Size));
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            content.Add(streamContent, "file", file.Name);

            var response = await httpClient.PostAsync("api/file/upload", content);
            if (response.IsSuccessStatusCode)
            {
                uploadMessage = "Good";
            }
            else
            {
                uploadMessage = "Error";
            }
        }
    }
}
