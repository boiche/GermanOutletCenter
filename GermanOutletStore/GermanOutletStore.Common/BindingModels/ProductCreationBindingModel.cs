using GermanOutletStore.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GermanOutletStore.Common.BindingModels
{
    public class ProductCreationBindingModel
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public int ProductId { get; set; }

        public string Description { get; set; }

        [Required]                
        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public string BrandName { get; set; }

        public int BrandId { get; set; }

        public int TypeId { get; set; }

        public List<bool> AvailableSizes { get; set; }

        public List<ProductType> Types { get; set; }
        public List<Size> AllSizes { get; set; }

        public IFormFile UploadedFile { get; set; }
    }
}
