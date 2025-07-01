using Microsoft.AspNetCore.Http;

namespace CARTER.Models.Common
{
    public class FileUploadRequest
    {
        public IFormFile File { get; set; }
    }
}
