﻿using AutoMapper;
using DIY.Castle.Web.Helpers;
using DIY.Castle.Web.Models;
using DIY.Castle.Web.Models.Response;
using DIY.Castle.Web.Models.ViewModels;
using DIY.Castle.Web.Services.ProductsService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            this.ViewData["titleText"] = "CART";

            var cart = SessionHelper.GetObjectFromJson<List<ProductCartModel>>(HttpContext.Session, "cart");
            var totalPrice = cart == null
               ? Math.Round(0.00M, 2)
               : Math.Round(cart.Sum(p => p.Product.Price * p.Quantity), 2);

            var viewModel = new CartViewModel
            {
                Cart = cart,
                TotalPrice = totalPrice,
            };

            return View(viewModel);
        }

        [Route("GetTotalPrice")]
        public IActionResult GetTotalPrice()
        {
            var cart = SessionHelper.GetObjectFromJson<List<ProductCartModel>>(HttpContext.Session, "cart");
            var totalPrice = cart == null
                ? Math.Round(0.00M, 2)
                : Math.Round(cart.Sum(p => p.Product.Price * p.Quantity), 2);

            string response = totalPrice.ToString("0.00");
            return this.Ok(response);
        }

        [Route("GetSubTotalPrice/{id}")]
        public IActionResult GetSubTotalPrice(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<ProductCartModel>>(HttpContext.Session, "cart");

            int index = GetItemIndexInCart(id);
            var cartProduct = index != -1 ? cart[index] : null;

            var subTotalPrice = cartProduct == null ? 0.00M :
               Math.Round((cartProduct.Quantity * cartProduct.Product.Price), 2);

            string response = subTotalPrice.ToString("0.00");
            return this.Ok(response);
        }

        [Route("AddToBasket/{id}/{quantity}")]
        public IActionResult AddToBasket(int id, int quantity)
        {
            try
            {
                var product = this._productsService.GetProductById(id);
                var productModel = this._productsService.GetProductModel(product);
                bool itemAlreadyExists = false;
                decimal totalPrice = 0.00M;
                int updatedQuantity = 0;
                int updatedTotalQuantity = 0;
                string imageSource = productModel.ImagesSourcePaths.Any() ? productModel.ImagesSourcePaths[0] : string.Empty;

                if (SessionHelper.GetObjectFromJson<List<ProductCartModel>>(HttpContext.Session, "cart") == null)
                {
                    var cart = new List<ProductCartModel>();

                    cart.Add(new ProductCartModel
                    {
                        Product = productModel,
                        Quantity = quantity
                    });

                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

                    totalPrice = productModel.Price;
                    updatedQuantity = quantity;
                    updatedTotalQuantity = 1;
                }
                else
                {
                    List<ProductCartModel> cart = SessionHelper.GetObjectFromJson<List<ProductCartModel>>(HttpContext.Session, "cart");

                    int index = GetItemIndexInCart(id);

                    // If the item already exists in the cart
                    if (index != -1)
                    {
                        cart[index].Quantity += quantity;
                        itemAlreadyExists = true;

                        updatedQuantity = cart[index].Quantity;
                    }
                    // If it doesn't
                    else
                    {
                        cart.Add(new ProductCartModel
                        {
                            Product = productModel,
                            Quantity = quantity
                        });

                        updatedQuantity = quantity;
                    }

                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

                    totalPrice = cart == null
                        ? Math.Round(0.00M, 2)
                        : Math.Round(cart.Sum(p => p.Product.Price * p.Quantity), 2);
                    updatedTotalQuantity = cart.Count();
                }

                var response = new CartUpdateResponseModel()
                {
                    ItemAlreadyExists = itemAlreadyExists,
                    UpdatedPrice = totalPrice.ToString("0.00"),
                    UpdatedQuantity = updatedQuantity,
                    UpdatedTotalQuantity = updatedTotalQuantity,
                    ImageSource = imageSource,
                };

                return this.Ok(Json(response));
            }
            catch (Exception)
            {
                return this.BadRequest();
            }

        }

        [Route("Remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<ProductCartModel> cart = SessionHelper.GetObjectFromJson<List<ProductCartModel>>(HttpContext.Session, "cart");
            int index = GetItemIndexInCart(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return NoContent();
        }

        [Route("IncreaseQuantity/{id}")]
        public IActionResult IncreaseQuantity(int id)
        {
            List<ProductCartModel> cart = SessionHelper.GetObjectFromJson<List<ProductCartModel>>(HttpContext.Session, "cart");

            int index = GetItemIndexInCart(id);

            if (index != -1)
            {
                cart[index].Quantity++;
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return NoContent();
        }

        [Route("DecreaseQuantity/{id}")]
        public IActionResult DecreaseQuantity(int id)
        {
            List<ProductCartModel> cart = SessionHelper.GetObjectFromJson<List<ProductCartModel>>(HttpContext.Session, "cart");

            int index = GetItemIndexInCart(id);

            if (index != -1 &&
                cart[index].Quantity - 1 > 0)
            {
                cart[index].Quantity--;
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return NoContent();
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
