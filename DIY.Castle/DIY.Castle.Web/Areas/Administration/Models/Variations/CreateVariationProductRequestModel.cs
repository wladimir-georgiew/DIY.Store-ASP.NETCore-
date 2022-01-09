using System;
using System.ComponentModel.DataAnnotations;

namespace DIY.Castle.Web.Areas.Administration.Models.Variations
{
    public class CreateVariationProductRequestModel : BaseVariationProductModel
    {

        [Required(ErrorMessage = "Неуспешно свързване към продукт")]
        public int ProductId { get; set; }
    }
}
