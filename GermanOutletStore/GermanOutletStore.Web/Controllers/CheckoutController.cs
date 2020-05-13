using AutoMapper;
using GermanOutletStore.Common.BindingModels;
using GermanOutletStore.Common.ViewModels;
using GermanOutletStore.Data;
using GermanOutletStore.Models;
using GermanOutletStore.Web.Extensions;
using GermanOutletStore.Web.Helpers.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GermanOutletStore.Web.Controllers
{
    public class CheckoutController : BaseController
    {
        private readonly List<ProductShoppingCartViewModel> allProducts;
        private readonly UserManager<User> userManager;

        public CheckoutController(StoreDbContext context, IMapper mapper, UserManager<User> userManager) : base (context, mapper)
        {
            allProducts = new List<ProductShoppingCartViewModel>();
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Cart()
        {
            GetAllProductsInCart();

            return View(allProducts);
        }

        [HttpPost]
        public IActionResult Cart(List<ProductShoppingCartViewModel> allProducts)
        {
            foreach (var product in allProducts)
            {
                string currentKey = $"{product.Name}{product.Size}ShoppingCart";
                
                this.HttpContext.Session.Put(currentKey, product);
            }

            return this.View(allProducts);
        }

        [HttpGet]
        public IActionResult Remove(int id, string Size)
        {
            var toRemove = context.Products.First(x => x.Id == id);
            this.HttpContext.Session.Remove($"{toRemove.Name}{Size}ShoppingCart");

            return this.RedirectToAction("Cart", "Checkout");
        }

        [HttpGet][Authorize]
        public IActionResult Checkout()
        {
            List<ProductCheckoutViewModel> products = new List<ProductCheckoutViewModel>();

            GetAllProductsInCart();

            products = this.mapper.Map<List<ProductCheckoutViewModel>>(allProducts);

            CheckoutBindingModel model = new CheckoutBindingModel
            {
                Countries = GetAllCountries(),
                OrderedProducts = products,
                Total = 0,
            };

            foreach (var prod in this.allProducts)
            {
                if (prod.SaleId == null) model.Total += prod.Price * prod.Quantity;
                else model.Total += prod.Sale.DiscountPrice * prod.Quantity;
            }

            return this.View(model);
        }

        [HttpPost][Authorize]
        public IActionResult Checkout(CheckoutBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                this.TempData.Put("__Message", new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = "Please re-enter your credentials",
                });
                model.Countries = GetAllCountries();
                GetAllProductsInCart();
                model.OrderedProducts = this.mapper.Map<List<ProductCheckoutViewModel>>(allProducts);
                return this.View(model);
            }
            
            RegisterOrder(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Your order was successfully submited.",
            });

            return this.RedirectToAction("Index", "Home");
        }

        private void RegisterOrder(CheckoutBindingModel model)
        {
            Order order = this.mapper.Map<Order>(model);
            order.CustomerId = userManager.GetUserId(this.User);
            context.Orders.Add(order);
            context.SaveChanges();

            GetAllProductsInCart();

            foreach (var product in allProducts)
            {
                ProductOrders newOrder = new ProductOrders()
                {
                    IsDelivered = false,
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = product.Quantity,
                    SizeId = context.Sizes.First(x=>x.Name == product.Size).Id,
                };

                context.ProductOrders.Add(newOrder);
            }

            context.SaveChanges();
        }
        private List<string> GetAllCountries()
        {
            List<string> result = new List<string>();

            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo info in getCultureInfo)
            {
                RegionInfo region = new RegionInfo(info.LCID);
                if (!(result.Contains(region.EnglishName)))
                {
                    result.Add(region.EnglishName);
                }
            }

            result.Sort();

            return result;
        }
        private void GetAllProductsInCart()
        {
            string[] allProductsNames = this.HttpContext.Session.Keys.Where(x => x.Contains("Cart")).ToArray();

            foreach (string name in allProductsNames)
            {
               var product = this.HttpContext.Session.Get<ProductShoppingCartViewModel>(name);
               
                if (product.SaleId != null)
                {
                    product.Sale = context.Sales.First(x => x.ProductId == product.Id);
                }
                allProducts.Add(product);
            }
        }
    }
}