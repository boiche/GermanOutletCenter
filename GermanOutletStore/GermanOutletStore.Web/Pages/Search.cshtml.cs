using GermanOutletStore.Common.ViewModels;
using GermanOutletStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GermanOutletStore.Web.Pages
{
    public class SearchModel : PageModel
    {
        private readonly StoreDbContext context;

        public SearchModel(StoreDbContext context)
        {
            this.context = context;
            this.SearchResults = new List<SearchResultsViewModel>();
        }

        [BindProperty]
        public string SearchTerm { get; set; }
        public List<SearchResultsViewModel> SearchResults { get; set; }

        public void OnGet(string searchTerm)
        {
            this.SearchTerm = searchTerm;
            if (string.IsNullOrEmpty(SearchTerm))
            {
                return;
            }
        
            List<SearchResultsViewModel> products = context.Products
                .Where(x => x.Name.ToLower().Contains(SearchTerm.ToLower()))
                .Select(x => new SearchResultsViewModel()
                {
                    Name = x.Name,
                    Price = x.Price,
                    ProductId = x.Id,
                    ImagePath = x.ImagePath,
                    SaleId = x.SaleId,                    
                    SearchResult = x.Name
                })
                .ToList();

            this.SearchResults.AddRange(products);

            foreach (var result in this.SearchResults)
            {
                if (result.SaleId != null)
                {
                    result.IsOnSale = true;
                    result.Sale = context.Sales.First(x => x.ProductId == result.ProductId);
                }
                else
                {
                    result.IsOnSale = false;
                }
            }
        }
    }
}