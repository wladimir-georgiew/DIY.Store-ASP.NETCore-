using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace DIY.Castle.Web.Services.UploadFileService
{
    public class UploadFileService : IUploadFileService
    {
        private readonly IWebHostEnvironment hostEnvironment;

        public UploadFileService(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }
        
        public string UploadFile(IFormFile file)
        {
            if (file == null)
            {
                return string.Empty;
            }
            
            string uploadsFolder = Path.Combine(this.hostEnvironment.WebRootPath, "images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);

            return "/images/" + uniqueFileName;
        }
    }
}
