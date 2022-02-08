using System.Collections.Generic;

namespace DIY.Castle.Web.Models.ViewModels
{
    public class HomePageViewModel
    {
        public List<ProductModel> LatestProducts { get; set; }

        public List<ProductModel> RandomProducts { get; set; }
    }
}
