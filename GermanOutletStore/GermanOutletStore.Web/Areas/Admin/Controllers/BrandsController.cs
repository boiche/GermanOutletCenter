using AutoMapper;
using GermanOutletStore.Common.BindingModels;
using GermanOutletStore.Common.ViewModels;
using GermanOutletStore.Data;
using GermanOutletStore.Models;
using GermanOutletStore.Web.Extensions;
using GermanOutletStore.Web.Helpers.Messages;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GermanOutletStore.Web.Areas.Admin.Controllers
{
    public class BrandsController : AdminController
    {
        public BrandsController(StoreDbContext context, IMapper mapper) : base(context, mapper) { }

        [HttpGet]
        public IActionResult Create(ProductCreationBindingModel model)
        {
            BrandCreationBindingModel brandModel = new BrandCreationBindingModel()
            {
                ProductId = model.ProductId,
            };

            return View(brandModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandCreationBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                this.TempData.Put<MessageModel>("__Message", new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = "Invalid input.",
                });

                return this.View(model);
            }                   

            Brand brandToAdd = this.mapper.Map<Brand>(model);
            context.Brands.Add(brandToAdd);

            if (model.ProductId != 0)
            {
                Product product = context.Products.First(x => x.Id == model.ProductId);
                product.BrandId = brandToAdd.Id;
            }
            
            context.SaveChanges();

            if (model.UploadedFile != null) await this.CheckAndUploadFile(model);

            this.TempData.Put<MessageModel>("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = $"Brand {brandToAdd.Name} was successfully added.",
            });

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AllBrands()
        {
            IEnumerable<AllBrandsViewModel> model = this.mapper.Map<IEnumerable<AllBrandsViewModel>>(context.Brands);

            foreach (AllBrandsViewModel brand in model)
            {
                brand.ProductCount = context.Products.Count(x => x.BrandId == brand.Id);
            }

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Brand brand = context.Brands.First(x => x.Id == id);
            BrandCreationBindingModel model = this.mapper.Map<BrandCreationBindingModel>(brand);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BrandCreationBindingModel model)
        {
            Brand toEdit = context.Brands.First(x => x.Name == model.OldName);           

            if (model.UploadedFile != null) await this.CheckAndUploadFile(model);

            toEdit.ImagePath = model.ImagePath;
            toEdit.Description = model.Description;
            toEdit.Name = model.NewName;

            context.SaveChanges();

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = $"{toEdit.Name} was successfully edited.",
            });

            return this.RedirectToAction("AllBrands", "Brands");
        }

        private async Task CheckAndUploadFile(BrandCreationBindingModel formFile)
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