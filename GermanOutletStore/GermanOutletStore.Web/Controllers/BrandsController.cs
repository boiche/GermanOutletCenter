using AutoMapper;
using GermanOutletStore.Common.ViewModels;
using GermanOutletStore.Data;
using GermanOutletStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GermanOutletStore.Web.Controllers
{
    public class BrandsController : BaseController
    {     
        public BrandsController(StoreDbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public IActionResult AllProducts(string brand)
        {
            Brand searched = context.Brands.First(x => x.Name == brand);
            var model = this.mapper.Map<IEnumerable<ProductViewModel>>(context.Products.Where(x => x.BrandId == searched.Id));            

            return this.View(model);
        }
    }
}