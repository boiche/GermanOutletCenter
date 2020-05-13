using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GermanOutletStore.Common.BindingModels
{
    public class BrandCreationBindingModel
    {
        [Required]
        public string NewName { get; set; }
        public string OldName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int ProductId { get; set; }        
        public IFormFile UploadedFile { get; set; }
    }
}
