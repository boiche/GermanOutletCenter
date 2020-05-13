using AutoMapper;
using GermanOutletStore.Common.BindingModels;
using GermanOutletStore.Common.ViewModels;
using GermanOutletStore.Data;
using GermanOutletStore.Models;
using GermanOutletStore.Web.Helpers.Messages;
using Microsoft.AspNetCore.Mvc;
using GermanOutletStore.Web.Extensions;
using System.Collections.Generic;
using System.Linq;
using GermanOutletStore.Services.Products;
using Microsoft.Extensions.Caching.Memory;
using System.IO;
using System.Threading.Tasks;
using GermanOutletStore.Common;

namespace GermanOutletStore.Web.Areas.Admin.Controllers
{
    public class ProductsController : AdminController
    {
        private readonly ProductManager productManager;
        private readonly IMemoryCache cache;        

        public ProductsController(StoreDbContext context, IMapper mapper, ProductManager productManager, IMemoryCache cache) : base (context, mapper)
        {
            this.productManager = productManager;
            this.cache = cache;            
        }

        [HttpGet]
        public IActionResult Create()
        {
            int size = default;
            ProductCreationBindingModel model = new ProductCreationBindingModel()
            {
                Types = context.Types.OrderBy(x => x.Name).ToList(),
                AllSizes = context.Sizes.Where(x => int.TryParse(x.Name, out size) == false).OrderBy(x => x.Id).ToList(),
                AvailableSizes = new List<bool>(),                       
            };            

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreationBindingModel bindModel)
        {            
            if (this.ModelState.IsValid == false)
            {
                this.TempData.Put("__Message", new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = $"Invalid input.",
                });

                bindModel.Types = context.Types.ToList();
                return this.View(bindModel);
            }

            if (bindModel.TypeId == context.Types.First(x => x.Name == "Shoes").Id)  
            {
                return this.RedirectToAction("CreateShoes", "Products", bindModel);
            }

            Product productToAdd = new Product()
            {
                Name = bindModel.Name,
                Description = bindModel.Description,
                Price = bindModel.Price,
                IsInStock = true,
                Rating = 0,
                TypeId = bindModel.TypeId,
                ImagePath = bindModel.ImagePath,
                BrandId = context.Brands.First(x => x.Name == bindModel.BrandName).Id,
                SaleId = null,                
            };          

            bindModel.BrandId = context.Brands.First(x => x.Name == bindModel.BrandName).Id;            
            productToAdd.BrandId = bindModel.BrandId;
            context.Products.Add(productToAdd);
            context.SaveChanges();
            bindModel.ProductId = productToAdd.Id;

            List<ProductSize> availableSizes = productManager.GetAvailableSizes(
                bindModel, 
                productToAdd,
                context.Types.First(x => x.Id == bindModel.TypeId).Name);
            

            this.context.ProductSizes.AddRange(availableSizes);
            context.SaveChanges();

            if (bindModel.UploadedFile != null) await this.CheckAndUploadFile(bindModel);

            if (bindModel.BrandName == "Other")
            {
                return this.RedirectToAction("Create", "Brands", bindModel);
            }

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = $"{productToAdd.Name} was successfully created.",
            });

            return this.RedirectToAction("AllProducts", "Products");
        }

        [HttpGet]
        public IActionResult CreateShoes(ProductCreationBindingModel model)
        {
            int size = default;
            model.AvailableSizes.Clear();
            model.Types = context.Types.OrderBy(x => x.Name).ToList();
            model.AllSizes = context.Sizes.Where(x => int.TryParse(x.Name, out size) == true).OrderBy(x => x.Id).ToList();            

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShoesPost(ProductCreationBindingModel model)
        {
            if (ModelState.IsValid == false)
            {
                this.TempData.Put("__Message", new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = $"Invalid input.",
                });

                model.Types = context.Types.ToList();
                return this.View(model);
            }

            model.BrandId = context.Brands.First(x => x.Name == model.BrandName).Id;

            Product productToAdd = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                IsInStock = true,
                Rating = 0,
                TypeId = model.TypeId,
                ImagePath = model.ImagePath,
                BrandId = model.BrandId,
            };

            this.context.Products.Add(productToAdd);

            List<ProductSize> availableSizes = productManager.GetAvailableSizes(
                model,
                productToAdd,
                context.Types.First(x => x.Id == model.TypeId).Name);
            
            this.context.ProductSizes.AddRange(availableSizes);
            this.context.SaveChanges();

            model.ProductId = productToAdd.Id;

            if (model.BrandName == "Other")
            {
                return this.RedirectToAction("Create", "Brands", model);
            }

            if (model.UploadedFile != null) await this.CheckAndUploadFile(model);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = $"{productToAdd.Name} was successfully created.",
            });

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AllProducts()
        {            
            var products = context.Products.ToList();
            var sizes = context.ProductSizes.ToList();
            IEnumerable<ProductViewModel> model = this.mapper.Map<IEnumerable<ProductViewModel>>(products);
            for (int i = 0; i < model.Count(); i++)
            {
                var current = model.ElementAt(i);
                current.AvailableSizes = sizes.Where(x => model.ElementAt(i).Id == x.ProductId).ToList();
                if (products[i].SaleId != null)
                {
                    current.IsOnSale = true;
                }
                else current.IsOnSale = false;
            }

            this.cache.GetOrCreate("AllProductsCache", entry => model);

            return this.View(model);
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            Product product = productManager.GetProduct(id);
            ProductCreationBindingModel productToEdit = this.mapper.Map<ProductCreationBindingModel>(product);
            string productType = context.Types.First(x => x.Id == product.TypeId).Name;
            int a = 0;

            if (productType == "Shoes") productToEdit.AllSizes = context.Sizes.Where(x => int.TryParse(x.Name, out a)).ToList();
            else productToEdit.AllSizes = context.Sizes.Where(x => int.TryParse(x.Name, out a) == false).ToList();

            this.TempData.Put("AllSizes", productToEdit.AllSizes);
            this.TempData.Put("ProductName", product.Name);

            return this.View(productToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductCreationBindingModel bindModel, int id)
        {
            if (ModelState.IsValid == false)
            {
                this.TempData.Put("__Message", new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = $"Invalid input.",
                });

                bindModel.AllSizes = this.TempData.Get<List<Size>>("AllSizes");
                bindModel.Name = this.TempData.Get<string>("ProductName");
                
                bindModel.Types = context.Types.ToList();
                return this.View(bindModel);
            }

            Product toEdit = this.productManager.GetProduct(id);
            productManager.EditProduct(bindModel, toEdit, context.Types.First(x => x.Id == toEdit.TypeId).Name);

            if (bindModel.UploadedFile != null) await this.CheckAndUploadFile(bindModel);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = $"{toEdit.Name} was successfully edited.",
            });

            cache.Remove("AllProductsCache");

            return this.RedirectToAction("AllProducts", "Products");
        }

        public IActionResult ChangeStockOutOfStock(int id)
        {
            Product productToChange = context.Products.First(x => x.Id == id);
            List<ProductSize> productSizesToChange = context.ProductSizes.Where(x => x.ProductId == productToChange.Id).ToList();
            productSizesToChange.ForEach(x => x.IsInStock = false);
            productToChange.IsInStock = false;
            context.SaveChanges();

            return this.RedirectToAction("AllProducts", "Products");
        }

        public IActionResult ChangeStockInStock(int id)
        {
            Product productToChange = context.Products.First(x => x.Id == id);
            List<ProductSize> productSizesToChange = context.ProductSizes.Where(x => x.ProductId == productToChange.Id).ToList();
            productSizesToChange.ForEach(x => x.IsInStock = true);
            productToChange.IsInStock = true;
            context.SaveChanges();

            return this.RedirectToAction("AllProducts", "Products");
        }

        public IActionResult Delete(int id)
        {
            productManager.Delete(id);

            return this.RedirectToAction("AllProducts", "Products");
        }

        [HttpGet]
        public IActionResult OnSale(int id)
        {
            Product product = productManager.GetProduct(id);
            SaleCreationBindingModel model = this.mapper.Map<SaleCreationBindingModel>(product);

            return this.View(model);
        }

        [HttpPost]
        public IActionResult OnSale(SaleCreationBindingModel model)
        {
            if (ModelState.IsValid == false || model.StartsOn >= model.EndsOn || model.OldPrice <= model.NewPrice)
            {
                this.TempData.Put("__Message", new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = $"Invalid input.",
                });

                return this.View(model);
            }

            Sale newSale = new Sale()
            {
                DiscountPrice = model.NewPrice,
                StartsOn = model.StartsOn,
                EndsOn = model.EndsOn,
                ProductId = model.ProductId,                 
            };

            context.Sales.Add(newSale);
            productManager.PutOnSale(model.ProductId, newSale.Id);                        

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = $"Successfully put {model.ProductName} on sale.",
            });

            return this.RedirectToAction("AllProducts", "Products");
        }

        public IActionResult RemoveSale(int id)
        {
            productManager.RemoveSale(id);

            return this.RedirectToAction("AllProducts");
        }        


        private async Task CheckAndUploadFile(ProductCreationBindingModel formFile)
        {
            char[] notAllowedSymbols = new char[]
            {
                '“', '|', '?', ':', '*', '<', '>', '#', '&', '+', '%', ',', '{', '}', '[', ']', '~'
            };
            string fileName = formFile.ImagePath.Split('/').Last();
            string oldFileName = formFile.ImagePath.Split('/').Last();

            while (fileName.IndexOfAny(notAllowedSymbols, 0) > 0)
            {
                fileName = fileName.Remove(fileName.IndexOfAny(notAllowedSymbols, 0), 1);
            }

            formFile.ImagePath = formFile.ImagePath.Replace(oldFileName, fileName);
            string directory = Directory.GetCurrentDirectory();
            string path = directory + formFile.ImagePath;
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            await formFile.UploadedFile.CopyToAsync(stream);            
        }
    }
}