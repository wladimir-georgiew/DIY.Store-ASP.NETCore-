using Microsoft.AspNetCore.Http;

namespace DIY.Castle.Web.Services.UploadFileService
{
    public interface IUploadFileService
    {
        /// <summary>
        /// Uploads image in the images folder
        /// </summary>
        /// <param name="file"></param>
        /// <returns>The string ready to be saved in the database</returns>
        public string UploadFile(IFormFile file);
    }
}
