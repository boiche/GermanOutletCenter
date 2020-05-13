using AutoMapper;
using GermanOutletStore.Common.ViewModels;
using GermanOutletStore.Data;
using GermanOutletStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;

namespace GermanOutletStore.Web.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IMemoryCache cache;

        public ProductsController(StoreDbContext context, IMapper mapper, IMemoryCache cache) : base(context, mapper)
        {
            this.cache = cache;
        }

        [HttpGet]
        public IActionResult AllCategories()
        {
            var allCategories = this.context.Types.ToList();
            var model = this.mapper.Map<IEnumerable<AllCategoriesViewModel>>(allCategories);

            this.cache.GetOrCreate("AllCategoriesCache", entry => model);

            return View(model);
        }

        [HttpGet]        
        public IActionResult AllProducts(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                var model = this.mapper.Map<IEnumerable<ProductViewModel>>(context.Products.ToList());

                for (int i = 0; i < model.Count(); i++)
                {
                    var currentProd = model.ElementAt(i);
                    if (currentProd.SaleId == 0) currentProd.IsOnSale = false;
                    else
                    {
                        currentProd.IsOnSale = true;
                        currentProd.Sale = context.Sales.First(x => x.Id == currentProd.SaleId);
                    }
                }

                this.cache.GetOrCreate("AllProductsCache", entry => model);

                return this.View(model);
            }
            else
            {
                ProductType productType = context.Types.First(x => x.Name == type);
                var allProducts = context.Products.Where(x => x.TypeId == productType.Id).ToList();
                var model = this.mapper.Map<IEnumerable<ProductViewModel>>(allProducts);
                model.Select(x => x.TypeId == productType.Id);

                for (int i = 0; i < model.Count(); i++)
                {
                    var currentProd = model.ElementAt(i);
                    if (currentProd.SaleId == 0) currentProd.IsOnSale = false;
                    else
                    {
                        currentProd.IsOnSale = true;
                        currentProd.Sale = context.Sales.First(x => x.Id == currentProd.SaleId);
                    }
                }

                return this.View(model);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Product product = context.Products.First(x => x.Id == id);
            ProductViewModel model = this.mapper.Map<ProductViewModel>(product);

            return this.View(model);
        }
    }
}