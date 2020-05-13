using GermanOutletStore.Models;
using System.Collections.Generic;

namespace GermanOutletStore.Common.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string ImagePath { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
        public bool IsInStock { get; set; }
        public bool IsOnSale { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public List<ProductSize> AvailableSizes { get; set; }        
    }
}
