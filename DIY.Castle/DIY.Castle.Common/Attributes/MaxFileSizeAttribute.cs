using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIY.Castle.Common.Attributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            this.maxFileSize = maxFileSize;
        }

        public string GetErrorMessage()
        {
            return $"Maximum allowed file size is {this.maxFileSize / 1024 / 1024} mb.";
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            if (value is List<IFormFile> files)
            {
                foreach (var item in files)
                {
                    if (item.Length > this.maxFileSize)
                    {
                        return new ValidationResult(this.GetErrorMessage());
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
