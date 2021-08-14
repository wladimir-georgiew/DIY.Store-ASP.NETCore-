using Microsoft.AspNetCore.Http;

namespace DIY.Castle.Web.Services.UploadFileService
{
    public interface IUploadFileService
    {
        public string GetUploadedFileName(IFormFile file);
    }
}
