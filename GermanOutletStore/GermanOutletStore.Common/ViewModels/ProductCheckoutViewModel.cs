using GermanOutletStore.Models;
using System.ComponentModel.DataAnnotations;

namespace GermanOutletStore.Common.ViewModels
{
    public class ProductCheckoutViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public int? SaleId { get; set; }
        public Sale Sale { get; set; }
        public int Quantity { get; set; }
        public int OldQuantity { get; set; }
        public decimal Subtotal { get; set; }
        public string Size { get; set; }
        public bool IsOnSale { get; set; }
    }
}
