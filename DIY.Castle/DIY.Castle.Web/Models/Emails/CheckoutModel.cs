using DIY.Castle.Web.Models.InputModels;
using DIY.Castle.Web.Models.ViewModels;

namespace DIY.Castle.Web.Models.Emails
{
    public class CheckoutModel
    {
        public CheckoutFormModel UserFormModel { get; set; }

        public CartViewModel CartModel { get; set; }
    }
}
