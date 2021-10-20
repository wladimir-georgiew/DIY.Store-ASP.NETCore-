using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace DIY.Castle.Common.Attributes
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            this.extensions = extensions;
        }

        public string GetErrorMessage()
        {
            return $"The provided photo/s extension is not supported!";
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            if (value is List<IFormFile> files)
            {
                foreach (var item in files)
                {
                    var extension = Path.GetExtension(item.FileName);
                    if (!this.extensions.Contains(extension.ToLower()))
                    {
                        return new ValidationResult(this.GetErrorMessage());
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
