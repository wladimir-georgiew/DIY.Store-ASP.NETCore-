using DIY.Castle.Data.Models;
using DIY.Castle.Web.Helpers;
using DIY.Castle.Web.Models.Emails;
using DIY.Castle.Web.Models.InputModels;
using DIY.Castle.Web.Models.ViewModels;
using DIY.Castle.Web.Services.EmailSender;
using DIY.Castle.Web.Services.ProductsService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Controllers
{
    public class CheckoutPageController : BaseController
    {
        private readonly IEmailSender emailSender;

        public CheckoutPageController(
            IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutFormModel model)
        {
            if (model.CourrierOption == GlobalConstants.DeliveryOptions.Econt)
            {
                if (model.DeliveryOption == GlobalConstants.DeliveryOptions.ToOffice &&
                    string.IsNullOrEmpty(model.EcontOffice))
                {
                    ModelState.AddModelError("EcontOffice", "Нямате избран офис");
                }
                else if (model.DeliveryOption == GlobalConstants.DeliveryOptions.ToAddress &&
                        string.IsNullOrEmpty(model.Address))
                {
                    ModelState.AddModelError("Address", "Нямате избран адрес");
                }
                else
                {
                    if (string.IsNullOrEmpty(model.DeliveryOption))
                    {
                        ModelState.AddModelError("DeliveryOption", "Трябва да изберете адрес или офис");
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(model.Address))
                {
                    ModelState.AddModelError("Address", "Нямате избран адрес");
                }
            }
            if (!ModelState.IsValid)
            {
                return this.View(nameof(Index), model);
            }

            var cart = SessionHelper.GetObjectFromJson<List<ProductCartModel>>(HttpContext.Session, "cart");
            var totalPrice = cart == null
                           ? Math.Round(0.00M, 2)
                           : Math.Round(cart.Sum(p => p.ProductVariation.Price * p.Quantity), 2);

            var cartModel = new CartViewModel()
            {
                Cart = cart,
                TotalPrice = totalPrice,
            };

            var checkoutModel = new CheckoutModel()
            {
                CartModel = cartModel,
                UserFormModel = model,
            };

            if (model.CourrierOption == GlobalConstants.DeliveryOptions.Econt)
            {
                if (model.DeliveryOption == GlobalConstants.DeliveryOptions.ToOffice)
                {
                    checkoutModel.UserFormModel.Address = model.EcontOffice;
                }
            }

            // Send Email To Customer Service
            var customerServiceViewHtml = await this.RenderViewAsync("~/Views/EmailTemplates/OrderTemplate.cshtml", checkoutModel, true);

            await this.emailSender.SendEmailAsync($"mail@abv.bg", "Akin-do Поръчка", $"akindo.customerservice@gmail.com", $"{model.FirstName} {model.LastName}", customerServiceViewHtml);

            // Send Email To Customer
            //await this.SendOrderSummaryEmailToUserAsync(checkoutModel);

            return this.RedirectToAction(nameof(OrderCompleted));
        }

        public IActionResult OrderCompleted()
        {
            return this.View();
        }

        private async Task<IActionResult> SendOrderSummaryEmailToUserAsync(CheckoutModel model)
        {
            var viewHtml = await this.RenderViewAsync("~/Views/EmailTemplates/OrderSummaryTemplate.cshtml", model, true);

            try
            {
                await this.emailSender.SendEmailAsync($"mail@abv.bg", $"Akin-do", $"{model.UserFormModel.CustomerEmailAddress}", $"Akin-do Поръчка - {model.CartModel.TotalPrice} лв.", viewHtml);

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
