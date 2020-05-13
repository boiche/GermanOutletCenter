using GermanOutletStore.Models;
using System.Collections.Generic;

namespace GermanOutletStore.Common.ViewModels
{
    public class AllProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public bool IsInStock { get; set; }
        public bool IsOnSale { get; set; }
        public List<ProductSize> AvailableSizes { get; set; }
    }
}
