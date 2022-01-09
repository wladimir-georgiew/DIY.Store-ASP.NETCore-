namespace DIY.Castle.Web.Areas.Administration.Models.Variations
{
    public class EditVariationProductRequestModel : BaseVariationProductModel
    {
        public int VariationId { get; set; }

        public int ProductId { get; set; }
    }
}
