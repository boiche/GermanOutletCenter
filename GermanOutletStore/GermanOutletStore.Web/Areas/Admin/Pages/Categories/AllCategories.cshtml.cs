using AutoMapper;
using GermanOutletStore.Common.ViewModels;
using GermanOutletStore.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace GermanOutletStore.Web.Areas.Admin.Pages.Categories
{
    public class AllCategoriesModel : PageModel
    {
        public StoreDbContext context;
        public IMapper mapper;
        public IEnumerable<CategoryViewModel> AllCategories { get; set; }

        public AllCategoriesModel(StoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void OnGet()
        {
            AllCategories = mapper.Map<IEnumerable<CategoryViewModel>>(context.Types.Where(a => a.Name != "Other"));
            foreach (CategoryViewModel type in AllCategories)
            {
                type.ProductCount = context.Products.Count(x => x.TypeId == type.Id);
            }
        }
    }
}