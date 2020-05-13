using GermanOutletStore.Models;

namespace GermanOutletStore.Common.ViewModels
{
    public class SearchResultsViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SearchResult { get; set; }
        public int? SaleId { get; set; }
        public Sale Sale { get; set; }
        public bool IsOnSale { get; set; }
        public string ImagePath { get; set; }
    }
}
