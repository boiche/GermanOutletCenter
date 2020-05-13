using AutoMapper;
using GermanOutletStore.Common.BindingModels;
using GermanOutletStore.Common.ViewModels;
using GermanOutletStore.Data;
using GermanOutletStore.Models;
using GermanOutletStore.Services.Products;
using GermanOutletStore.Web.Extensions;
using GermanOutletStore.Web.Helpers.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace GermanOutletStore.Web.Pages.Products
{
    public class DetailsModel : PageModel
    {
        public readonly StoreDbContext context;
        private readonly IMapper mapper;
        private readonly ProductManager productManager;

        [BindProperty]
        public Product Product { get; set; }
        public Brand Brand { get; set; }
        public List<Review> Reviews { get; set; }
        public List<int> AvailableSizes { get; set; }
        public List<string> SizesNames { get; set; }
        public OrderCreationBindingModel OrderModel { get; set; }
        public Sale Sale { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        [BindProperty]
        public string SizeName { get; set; }

        public DetailsModel(StoreDbContext context, IMapper mapper, ProductManager productManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.productManager = productManager;
            this.SizesNames = new List<string>();
        }

        public void OnGet(int id)
        {
            this.Product = context.Products.Find(id);
            this.Brand = context.Brands.First(x => x.Id == Product.BrandId);
            this.Reviews = context.Reviews.Where(x => x.ProductId == Product.Id).ToList();
            this.AvailableSizes = context.ProductSizes.Where(x => x.ProductId == Product.Id && x.IsInStock == true).Select(x => x.SizeId).ToList();
            this.Sale = context.Sales.FirstOrDefault(x => x.ProductId == id);
            foreach (int sizeId in AvailableSizes)
            {                
                string currentSizeName = context.Sizes.First(x => x.Id == sizeId).Name;
                SizesNames.Add(currentSizeName);
            }
        }

        public IActionResult OnPost()
        {
            Product current = productManager.GetProduct(Product.Id);

            if (current.IsInStock == false)
            {
                TempData.Put("__Message", new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = "This product is out of stock.",
                });

                this.OnGet(current.Id);

                return this.Page();
            }
            if (SizeName == null)
            {
                TempData.Put("__Message", new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = "Please select size.",
                });

                this.OnGet(current.Id);

                return this.Page();
            }

            string currentSessionKey = $"{current.Name}{SizeName}ShoppingCart";
            ProductShoppingCartViewModel model = new ProductShoppingCartViewModel()
            {
                Id = current.Id,
                Name = current.Name,                
                ImagePath = current.ImagePath,
                Price = current.Price,
                Quantity = Quantity,
                Subtotal = Quantity * current.Price,
                Size = SizeName,
                SaleId = current.SaleId == null ? null : current.SaleId,
            };

            if (this.HttpContext.Session.Keys.FirstOrDefault(x=>x == currentSessionKey) != null)
            {
                var result = this.HttpContext.Session.Get<ProductShoppingCartViewModel>(currentSessionKey);
                result.Quantity += model.Quantity;
                result.Subtotal += model.Subtotal;
                this.HttpContext.Session.Put(currentSessionKey, result);
            }

            else this.HttpContext.Session.Put(currentSessionKey, model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = $"{current.Name} was successfully added to your shopping cart. <a href=\"https://localhost:44386/Checkout/Cart\">View Cart >></a>",
            });

            return this.RedirectToPage("Details");
        }
    }
}