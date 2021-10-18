using DIY.Castle.Web.Helpers;
using DIY.Castle.Web.Models.InputModels;
using DIY.Castle.Web.Services.EmailSender;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Controllers
{
    public class CheckoutPageController : BaseController
    {
        private readonly IEmailSender emailSender;

        public CheckoutPageController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> SendOrderSummaryEmailAsync(CreateOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                // TODO..
            }

            var viewHtml = await this.RenderViewAsync("~/Views/EmailTemplates/OrderSummaryTemplate.cshtml", new CreateOrderInputModel(), true);

            try
            {
                await this.emailSender.SendEmailAsync($"sneakypeekymustard@gmail.com", $"DIY Castle Support", $"{model.EmailAddress}", $"Subject", viewHtml);

                return Ok();
            }
            catch (System.Exception msg)
            {
                // TODO... 

                return BadRequest();
            }

            
        }
    }
}
