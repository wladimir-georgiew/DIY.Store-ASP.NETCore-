using AutoMapper;
using DIY.Castle.Web.Helpers;
using DIY.Castle.Web.Models;
using DIY.Castle.Web.Models.ViewModels;
using DIY.Castle.Web.Services.ProductsService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DIY.Castle.Web.Controllers
{
    [Route("cart")]
    public class CartController : BaseController
    {
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        public CartController(
            IProductsService productsService,
            IMapper mapper)
        {
            this._productsService = productsService;
            this._mapper = mapper;
        }

        [Route("index")]
        public IActionResult Index()
        {
            this.ViewData["showSmallHeroBanner"] = true;
            this.ViewData["titleText"] = "CHECKOUT";

            var cart = SessionHelper.GetObjectFromJson<List<ProductCartModel>>(HttpContext.Session, "cart");
            var totalPrice = cart == null
                ? 0
                : cart.Sum(p => p.Product.Price * p.Quantity);

            var viewModel = new CartViewModel
            {
                Cart = cart,
                TotalPrice = totalPrice,
            };

            return View();
        }

        [Route("CartController/GetItems")]
        public IActionResult GetItemsInCart()
        {
            var cart = SessionHelper.GetObjectFromJson<List<ProductCartModel>>(HttpContext.Session, "cart");
            var totalPrice = cart == null
                ? 0
                : cart.Sum(p => p.Product.Price * p.Quantity);

            var viewModel = new CartViewModel
            {
                Cart = cart,
                TotalPrice = totalPrice,
            };

            return this.Ok(viewModel);
        }

        [Route("AddToBasket/{id}/{quantity}")]
        public IActionResult AddToBasket(int id, int quantity)
        {
            var product = this._productsService.GetProductById(id);
            var productModel = this._mapper.Map<ProductModel>(product);

            if (SessionHelper.GetObjectFromJson<List<ProductCartModel>>(HttpContext.Session, "cart") == null)
            {
                var cart = new List<ProductCartModel>();

                cart.Add(new ProductCartModel
                {
                    Product = productModel,
                    Quantity = quantity
                });

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<ProductCartModel> cart = SessionHelper.GetObjectFromJson<List<ProductCartModel>>(HttpContext.Session, "cart");

                int index = GetItemIndexInCart(id);

                // If the item already exists in the cart
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                // If it doesn't
                else
                {
                    cart.Add(new ProductCartModel
                    {
                        Product = productModel,
                        Quantity = quantity
                    });
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction("Index");
        }

        [Route("Remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<ProductCartModel> cart = SessionHelper.GetObjectFromJson<List<ProductCartModel>>(HttpContext.Session, "cart");
            int index = GetItemIndexInCart(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return Ok(cart);
        }

        private int GetItemIndexInCart(int id)
        {
            List<ProductCartModel> cart = SessionHelper.GetObjectFromJson<List<ProductCartModel>>(HttpContext.Session, "cart");

            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
