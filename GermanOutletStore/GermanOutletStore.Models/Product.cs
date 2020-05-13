using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GermanOutletStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }
        public string ImagePath { get; set; }
        public bool IsInStock { get; set; }
        public string Description { get; set; }

        public int? SaleId { get; set; }
        public Sale Sale { get; set; }

        public int TypeId { get; set; }
        public ProductType Type { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<ProductOrders> Orders { get; set; }        

        public ICollection<ProductSize> AvailableSizes { get; set; } //Clothes
    }
}
