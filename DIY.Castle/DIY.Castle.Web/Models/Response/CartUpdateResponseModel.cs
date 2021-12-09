namespace DIY.Castle.Web.Models.Response
{
    public class CartUpdateResponseModel
    {
        public bool ItemAlreadyExists { get; set; }

        public string UpdatedPrice { get; set; }

        public int UpdatedQuantity { get; set; }

        public int UpdatedTotalQuantity { get; set; }

        public string ImageSource { get; set; }
    }
}
